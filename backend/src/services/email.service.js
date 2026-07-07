const crypto = require('crypto');
const axios = require('axios');
const nodemailer = require('nodemailer');

const FROM_NAME = 'Hệ thống QLCafe';
const SUBJECT = 'QLCafe - Mã xác nhận khôi phục mật khẩu';

function buildOtpHtml(code) {
    return `
        <div style="background-color: #f6f9fc; padding: 40px 0; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="450" style="background-color: #ffffff; border-radius: 12px; box-shadow: 0 10px 25px rgba(0,0,0,0.05); overflow: hidden;">
                <tr>
                    <td style="background-color: #2c3e50; padding: 25px; text-align: center;">
                        <h1 style="color: #ffffff; margin: 0; font-size: 24px; letter-spacing: 2px; font-weight: 700;">QLCAFE</h1>
                    </td>
                </tr>

                <tr>
                    <td style="padding: 40px 30px; text-align: center;">
                        <h2 style="color: #1a202c; margin: 0 0 15px 0; font-size: 20px;">Xác nhận khôi phục mật khẩu</h2>
                        <p style="color: #4a5568; font-size: 15px; margin-bottom: 30px;">Xin chào,<br>Bạn vừa yêu cầu mã xác nhận để đặt lại mật khẩu. Vui lòng nhập mã dưới đây để tiếp tục:</p>

                        <div style="background-color: #f8fafc; border: 2px dashed #cbd5e0; border-radius: 8px; padding: 20px; margin: 0 auto 25px auto; width: 80%;">
                            <span style="font-size: 32px; font-weight: bold; color: #e74c3c; letter-spacing: 8px;">${code}</span>
                        </div>

                        <p style="color: #718096; font-size: 13px; font-style: italic; margin: 0;">
                            ⚠️ Mã có hiệu lực trong <b style="color: #e74c3c;">60 giây</b>.
                        </p>
                    </td>
                </tr>

                <tr>
                    <td style="padding: 20px 30px; background-color: #fdfdfd; border-top: 1px solid #edf2f7; text-align: center;">
                        <p style="color: #a0aec0; font-size: 12px; line-height: 1.4; margin: 0;">
                            Nếu bạn không yêu cầu mã này, vui lòng bỏ qua email hoặc liên hệ với bộ phận hỗ trợ để bảo mật tài khoản.
                        </p>
                        <p style="color: #a0aec0; font-size: 12px; margin: 10px 0 0;">&copy; 2026 QLCafe System. All rights reserved.</p>
                    </td>
                </tr>
            </table>
        </div>
    `;
}

// Render (gói free) chặn outbound SMTP 25/465/587 từ 26/09/2025 → trên cloud phải gửi
// qua HTTP API (port 443). Sender email phải được verify trong Brevo (Senders & IPs).
async function sendViaBrevo(toEmail, code) {
    await axios.post(
        'https://api.brevo.com/v3/smtp/email',
        {
            sender: { name: FROM_NAME, email: process.env.EMAIL_USER },
            to: [{ email: toEmail }],
            subject: SUBJECT,
            htmlContent: buildOtpHtml(code),
        },
        {
            headers: { 'api-key': process.env.BREVO_API_KEY },
            timeout: 15000,
        }
    );
}

async function sendViaGmailSmtp(toEmail, code) {
    const transporter = nodemailer.createTransport({
        host: 'smtp.gmail.com',
        port: 587,
        secure: false,
        auth: {
            user: process.env.EMAIL_USER,
            pass: process.env.EMAIL_PASS,
        },
        // Mặc định nodemailer chờ tới 120s mới báo lỗi; nếu SMTP bị chặn thì fail sớm cho rõ.
        connectionTimeout: 15000,
    });

    await transporter.sendMail({
        from: `"${FROM_NAME}" <${process.env.EMAIL_USER}>`,
        to: toEmail,
        subject: SUBJECT,
        html: buildOtpHtml(code),
    });
}

async function generateAndSendOTP(toEmail) {
    // crypto.randomInt = CSPRNG — Math.random() có thể dự đoán được, không dùng cho mã bảo mật
    const code = crypto.randomInt(10000000, 100000000).toString();

    try {
        if (process.env.BREVO_API_KEY) {
            await sendViaBrevo(toEmail, code);
        } else {
            await sendViaGmailSmtp(toEmail, code);
        }
    } catch (err) {
        // Lỗi Brevo nằm trong response body (message), lỗi SMTP nằm trong err.message.
        const detail = err.response?.data?.message || err.message;
        throw new Error(`Không gửi được email OTP: ${detail}`);
    }

    return code;
}

module.exports = { generateAndSendOTP };
