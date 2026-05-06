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
            <div style="font-family: Arial, sans-serif; line-height: 1.6; color: #333;">
                <h2 style="color: #2c3e50;">Xin chào,</h2>
                <p>Mã xác nhận của bạn là: <b style="color: #e74c3c;">${code}</b></p>
                <p>Mã có hiệu lực trong 60 giây.</p>
            </div>
        `
    });

    return code;
}

async function sendVerificationEmail(toEmail, code) {
    const transporter = createTransporter();

    await transporter.sendMail({
        from: `"Hệ thống QLCafe" <${process.env.EMAIL_USER}>`,
        to: toEmail,
        subject: 'QLCafe - Verification Code',
        text: `Mã xác nhận của bạn là: ${code}`
    });
}

module.exports = { generateAndSendOTP, sendVerificationEmail };
