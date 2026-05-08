const nodemailer = require('nodemailer');

function createTransporter() {
    return nodemailer.createTransport({
        host: 'smtp.gmail.com',
        port: 587,
        secure: false,
        auth: {
            user: process.env.EMAIL_USER,
            pass: process.env.EMAIL_PASS
        }
    });
}

async function generateAndSendOTP(toEmail) {
    const code = Math.floor(10000000 + Math.random() * 90000000).toString();
    const transporter = createTransporter();

    await transporter.sendMail({
        from: `"Hệ thống QLCafe" <${process.env.EMAIL_USER}>`,
        to: toEmail,
        subject: 'QLCafe - Mã xác nhận khôi phục mật khẩu',
        html: `
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
        `
    });

    return code;
}

module.exports = { generateAndSendOTP };
