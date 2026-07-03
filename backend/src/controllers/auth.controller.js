const authService = require('../services/firebase-auth.service');
const emailService = require('../services/email.service');
const otpService = require('../services/otp.service');
const { info } = require('../utils/logger');

// Quy tắc mật khẩu mạnh — khớp client Validation.IsValidPassword (phòng thủ phía server).
const STRONG_PASSWORD = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$/;

exports.login = async (req, res, next) => {
    try {
        const { email, password } = req.body;
        if (!email || !password) return res.status(400).json({ error: 'Missing email or password' });

        const result = await authService.loginEmployee(email, password);
        info('Employee logged in', { email });
        res.status(200).json(result);
    } catch (err) {
        const message = err.response?.data?.error?.message || err.message;
        res.status(401).json({ error: message });
    }
};

exports.checkEmailExists = async (req, res, next) => {
    try {
        const { email } = req.body;
        if (!email) return res.status(400).json({ error: 'Missing email' });

        await authService.checkEmailExists(email);
        res.status(200).json({ exists: true, message: 'Valid email address.' });
    } catch (err) {
        if (err.code === 'auth/user-not-found') {
            return res.status(404).json({ exists: false, message: 'Email address not found.' });
        }
        next(err);
    }
};

exports.generateOTP = async (req, res, next) => {
    try {
        const { toEmail } = req.body;
        if (!toEmail) return res.status(400).json({ error: 'Missing recipient email' });

        // Tạo + gửi mã qua email, rồi lưu HASH của mã ở server. KHÔNG trả mã về client.
        const code = await emailService.generateAndSendOTP(toEmail);
        await otpService.storeOtp(toEmail, code);
        res.status(200).json({ message: 'Verification code sent!' });
    } catch (err) {
        next(err);
    }
};

exports.verifyOTP = async (req, res, next) => {
    try {
        const { email, code } = req.body;
        if (!email || !code) return res.status(400).json({ error: 'Missing email or code' });

        // So sánh ở server; đúng -> phát reset-token dùng 1 lần.
        const resetToken = await otpService.verifyOtp(email, code);
        res.status(200).json({ message: 'OTP verified', resetToken });
    } catch (err) {
        if (err.status) return res.status(err.status).json({ error: err.message });
        next(err);
    }
};

exports.changePassword = async (req, res, next) => {
    try {
        const { email, oldPassword, newPassword } = req.body;
        if (!email || !oldPassword || !newPassword) {
            return res.status(400).json({ error: 'Missing email, oldPassword or newPassword' });
        }
        if (!STRONG_PASSWORD.test(newPassword)) {
            return res.status(400).json({
                error: 'Mật khẩu phải dài ít nhất 8 ký tự, gồm chữ hoa, chữ thường, chữ số và một ký tự đặc biệt.',
            });
        }
        try {
            await authService.changePassword(email, oldPassword, newPassword);
        } catch (e) {
            return res.status(401).json({ error: 'Mật khẩu hiện tại không đúng.' });
        }
        info('Password changed', { email });
        res.status(200).json({ message: 'Success' });
    } catch (err) {
        next(err);
    }
};

exports.updatePassword = async (req, res, next) => {
    try {
        const { email, newPassword, resetToken } = req.body;
        if (!email || !newPassword || !resetToken) {
            return res.status(400).json({ error: 'Missing email, newPassword or resetToken' });
        }
        // Kiểm tra độ mạnh Ở SERVER (không tin client) TRƯỚC khi tiêu reset-token,
        // để mật khẩu yếu không làm mất token (đỡ phải xác thực OTP lại).
        if (!STRONG_PASSWORD.test(newPassword)) {
            return res.status(400).json({
                error: 'Mật khẩu phải dài ít nhất 8 ký tự, gồm chữ hoa, chữ thường, chữ số và một ký tự đặc biệt.',
            });
        }
        // Chỉ cho đổi mật khẩu khi có reset-token hợp lệ (đã xác thực OTP ở server).
        await otpService.consumeResetToken(email, resetToken);
        await authService.updatePassword(email, newPassword);
        res.status(200).json({ message: 'Success' });
    } catch (err) {
        if (err.status) return res.status(err.status).json({ error: err.message });
        next(err);
    }
};
