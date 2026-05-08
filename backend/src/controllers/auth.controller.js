const authService = require('../services/firebase-auth.service');
const emailService = require('../services/email.service');
const { info } = require('../utils/logger');

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

        const code = await emailService.generateAndSendOTP(toEmail);
        res.status(200).json({ message: 'Verification code sent!', code });
    } catch (err) {
        next(err);
    }
};

exports.updatePassword = async (req, res, next) => {
    try {
        const { email, newPassword, secretKey } = req.body;
        await authService.updatePassword(email, newPassword, secretKey);
        res.status(200).json({ message: 'Success' });
    } catch (err) {
        if (err.status === 403) return res.status(403).json({ error: err.message });
        next(err);
    }
};
