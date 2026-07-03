namespace GUI
{
    // Cấu hình QR của quán.
    // ⟵⟵⟵ ĐIỀN THÔNG TIN NGÂN HÀNG THẬT CỦA QUÁN vào đây để QR chuyển khoản vào đúng tài khoản.
    //     (BankBin = mã BIN Napas 6 số của ngân hàng; AccountNo = số tài khoản nhận tiền.)
    internal static class QrConfig
    {
        public const string BankBin     = "970436";            // 970436 = Vietcombank · 970415 = VietinBank · 970436…
        public const string BankName    = "Vietcombank";
        public const string AccountNo   = "1234567890";        // ⟵ SỐ TÀI KHOẢN NHẬN TIỀN CỦA QUÁN
        public const string AccountName = "QUAN CAFE NHOM 2";

        // Trang tự đặt món (khách quét QR ở bàn để mở menu online, kèm mã bàn).
        public const string SelfOrderBaseUrl = "https://qlcafe.app/order";
    }
}
