const crypto = require('crypto');
const { db } = require('../config/firebase');

// Mã OTP và reset-token được lưu Ở SERVER (Realtime DB), không bao giờ trả về client.
const OTP_TTL_MS = 60 * 1000;              // mã có hiệu lực 60s (khớp email)
const RESET_TOKEN_TTL_MS = 1 * 60 * 1000;  // sau khi xác thực, có 1 phút để đặt mật khẩu
const MAX_ATTEMPTS = 5;                     // nhập sai quá số lần -> huỷ mã

// "Pepper" bằng secret phía server: kể cả khi node DB bị đọc, không thể brute-force
// hash của mã 8 chữ số nếu không biết APP_SECRET_KEY.
const PEPPER = process.env.APP_SECRET_KEY || '';
const sha256 = (s) => crypto.createHash('sha256').update(String(s) + PEPPER).digest('hex');
// Email chứa '.', '@'... không hợp lệ làm key RTDB -> dùng hash email làm key (cũng không lộ email).
const ref = (email) => db.ref('password_reset').child(sha256(String(email).trim().toLowerCase()));

const httpError = (message, status) => Object.assign(new Error(message), { status });

// Lưu HASH của mã (không lưu mã thật) kèm hạn dùng và bộ đếm số lần thử.
async function storeOtp(email, code) {
    await ref(email).set({
        codeHash: sha256(code),
        expiresAt: Date.now() + OTP_TTL_MS,
        attempts: 0,
    });
}

// So sánh mã Ở SERVER. Đúng -> phát một reset-token dùng 1 lần, hạn ngắn.
async function verifyOtp(email, code) {
    const node = ref(email);
    const data = (await node.once('value')).val();

    if (!data || !data.codeHash) {
        throw httpError('Mã không tồn tại hoặc đã được dùng. Vui lòng yêu cầu mã mới.', 400);
    }
    if (Date.now() > data.expiresAt) {
        await node.remove();
        throw httpError('Mã đã hết hạn. Vui lòng yêu cầu mã mới.', 400);
    }
    if ((data.attempts || 0) >= MAX_ATTEMPTS) {
        await node.remove();
        throw httpError('Nhập sai quá số lần cho phép. Vui lòng yêu cầu mã mới.', 429);
    }
    if (sha256(code) !== data.codeHash) {
        await node.child('attempts').set((data.attempts || 0) + 1);
        throw httpError('Mã xác nhận không đúng.', 400);
    }

    const resetToken = crypto.randomBytes(32).toString('hex');
    await node.set({
        resetTokenHash: sha256(resetToken),
        resetTokenExpiresAt: Date.now() + RESET_TOKEN_TTL_MS,
    });
    return resetToken;
}

// Kiểm tra reset-token khi đổi mật khẩu, rồi xoá (dùng 1 lần).
async function consumeResetToken(email, resetToken) {
    const node = ref(email);
    const data = (await node.once('value')).val();

    if (!data || !data.resetTokenHash) {
        throw httpError('Phiên đặt lại mật khẩu không hợp lệ. Vui lòng xác thực OTP lại.', 403);
    }
    if (Date.now() > data.resetTokenExpiresAt) {
        await node.remove();
        throw httpError('Phiên đặt lại mật khẩu đã hết hạn. Vui lòng xác thực OTP lại.', 403);
    }
    if (!resetToken || sha256(resetToken) !== data.resetTokenHash) {
        throw httpError('Token đặt lại mật khẩu không hợp lệ.', 403);
    }
    await node.remove();
}

module.exports = { storeOtp, verifyOtp, consumeResetToken };
