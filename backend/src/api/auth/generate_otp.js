const { onRequest } = require("firebase-functions/v2/https");
const nodemailer = require('nodemailer');
const { emailUserParam, emailPassParam } = require("../../config/firebase");

/**
 * API: generate_otp
 * Tạo mã OTP và gửi qua email.
 */
exports.generateAndSendOTP = onRequest(async (req, res) => {
    if (req.method !== 'POST') {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    const { toEmail } = req.body;
    if (!toEmail) {
        return res.status(400).send({ message: "Missing recipient information." });
    }

    try {
        const generatedCode = Math.floor(10000000 + Math.random() * 90000000).toString();

        const transporter = nodemailer.createTransport({
            host: "smtp.gmail.com",
            port: 587,
            secure: false, 
            auth: {
                user: emailUserParam.value(),
                pass: emailPassParam.value()
            }
        });

        const mailOptions = {
            from: `"Hệ thống QLCafe" <${emailUserParam.value()}>`,
            to: toEmail,
            subject: 'QLCafe - Mã xác nhận khôi phục mật khẩu',
            html: `
                <div style="font-family: Arial, sans-serif; line-height: 1.6; color: #333;">
                    <h2 style="color: #2c3e50;">Xin chào,</h2>
                    <p>Mã xác nhận của bạn là: <b style="color: #e74c3c;">${generatedCode}</b></p>
                    <p>Mã có hiệu lực trong 60 giây.</p>
                </div>
            `
        };

        await transporter.sendMail(mailOptions);
        
        return res.status(200).send({ 
            message: "Verification code has been sent successfully!", 
            code: generatedCode 
        });

    } catch (error) {
        console.error("SMTP mail delivery error:", error);
        return res.status(500).send({ message: "Server error when sending email" });
    }
});
