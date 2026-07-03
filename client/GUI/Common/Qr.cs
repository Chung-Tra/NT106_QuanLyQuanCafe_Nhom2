using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using QRCoder;

namespace GUI
{
    // Sinh mã QR THẬT (quét được bằng điện thoại) qua QRCoder:
    //   • VietQr()  — payload chuyển khoản chuẩn EMVCo / Napas 247: app ngân hàng khi quét
    //                 sẽ điền sẵn số tài khoản + số tiền + nội dung.
    //   • Url()     — QR chứa 1 đường link (dùng cho QR tự đặt món theo bàn).
    // Dùng PngByteQRCode (thuần managed, không phụ thuộc GDI của QRCoder) rồi nạp vào Bitmap.
    internal static class Qr
    {
        public static Bitmap Render(string content, int pixelsPerModule = 8)
        {
            using var gen  = new QRCodeGenerator();
            using var data = gen.CreateQrCode(content, QRCodeGenerator.ECCLevel.M);
            byte[] png = new PngByteQRCode(data).GetGraphic(pixelsPerModule);
            using var ms = new MemoryStream(png);
            return new Bitmap(ms);
        }

        public static Bitmap Url(string url, int px = 8) => Render(url, px);

        public static Bitmap VietQr(long amount, string addInfo, int px = 6)
            => Render(VietQrPayload(QrConfig.BankBin, QrConfig.AccountNo, amount, addInfo), px);

        // ---- EMVCo / VietQR (Napas 247) ----
        public static string VietQrPayload(string bankBin, string accountNo, long amount, string addInfo)
        {
            string merchant =
                Tlv("00", "A000000727") +                               // GUID Napas
                Tlv("01", Tlv("00", bankBin) + Tlv("01", accountNo)) +  // BIN + số TK
                Tlv("02", "QRIBFTTA");                                  // chuyển khoản tới tài khoản

            var sb = new StringBuilder();
            sb.Append(Tlv("00", "01"));                     // Payload Format Indicator
            sb.Append(Tlv("01", amount > 0 ? "12" : "11")); // 12 = giao dịch 1 lần (có số tiền)
            sb.Append(Tlv("38", merchant));
            sb.Append(Tlv("53", "704"));                    // tiền tệ VND
            if (amount > 0) sb.Append(Tlv("54", amount.ToString()));
            sb.Append(Tlv("58", "VN"));                     // quốc gia
            string info = Ascii(addInfo);
            if (info.Length > 0) sb.Append(Tlv("62", Tlv("08", info)));
            sb.Append("6304");                              // id+len của CRC
            sb.Append(Crc16(sb.ToString()).ToString("X4"));
            return sb.ToString();
        }

        private static string Tlv(string id, string value) => id + value.Length.ToString("D2") + value;

        // CRC-16/CCITT-FALSE (poly 0x1021, init 0xFFFF) — chuẩn checksum của EMVCo QR.
        private static ushort Crc16(string s)
        {
            ushort crc = 0xFFFF;
            foreach (byte b in Encoding.ASCII.GetBytes(s))
            {
                crc ^= (ushort)(b << 8);
                for (int i = 0; i < 8; i++)
                    crc = (crc & 0x8000) != 0 ? (ushort)((crc << 1) ^ 0x1021) : (ushort)(crc << 1);
            }
            return crc;
        }

        // Nội dung VietQR nên là ASCII không dấu, gọn.
        private static string Ascii(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";
            var sb = new StringBuilder();
            foreach (char c in s.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark) continue;
                if (c == 'đ') sb.Append('d');
                else if (c == 'Đ') sb.Append('D');
                else if (c < 128) sb.Append(c);
            }
            return sb.ToString().Trim();
        }
    }
}
