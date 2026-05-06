const { onRequest } = require("firebase-functions/v2/https");
const nodemailer = require('nodemailer');
const { emailUserParam, emailPassParam } = require("../../config/firebase");

/**
 * API: send_verification_email
 * Gửi mã xác nhận qua email.
 */
exports.sendVerificationEmail = onRequest(async (req, res) => {
    if (req.method !== 'POST') {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    const { toEmail, code } = req.body;

    if (!toEmail || !code) {
        return res.status(400).send({ message: "Missing info." });
    }

    try {
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
            subject: 'QLCafe - Verification Code',
            text: `Mã xác nhận của bạn là: ${code}`
        };

        await transporter.sendMail(mailOptions);
        return res.status(200).send({ message: "Sent successfully!" });

    } catch (error) {
        console.error("Email Error:", error.message);
        return res.status(500).send({ message: "Server error" });
    }
});
