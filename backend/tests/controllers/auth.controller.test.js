const { mockAuth } = require('../helpers/mockFirebase');

jest.mock('../../src/services/firebase-auth.service', () => ({
    loginEmployee: jest.fn(),
    checkEmailExists: jest.fn(),
    updatePassword: jest.fn(),
}));
jest.mock('../../src/services/email.service', () => ({
    generateAndSendOTP: jest.fn(),
}));
jest.mock('../../src/services/otp.service', () => ({
    storeOtp: jest.fn(),
    verifyOtp: jest.fn(),
    consumeResetToken: jest.fn(),
}));

const authController = require('../../src/controllers/auth.controller');
const authService = require('../../src/services/firebase-auth.service');
const emailService = require('../../src/services/email.service');
const otpService = require('../../src/services/otp.service');

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('auth.controller - login', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu email hoặc password', async () => {
        const req = { body: { email: 'a@cafe.com' } };
        const res = mockRes();
        await authController.login(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('đăng nhập thành công trả 200 với token', async () => {
        authService.loginEmployee.mockResolvedValue({
            token: 'firebase-token',
            user: { email: 'a@cafe.com', vai_tro: 'manager' },
        });

        const req = { body: { email: 'a@cafe.com', password: 'Pass@1234' } };
        const res = mockRes();
        await authController.login(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.json.mock.calls[0][0]).toHaveProperty('token');
    });

    test('trả 401 nếu sai thông tin đăng nhập', async () => {
        authService.loginEmployee.mockRejectedValue(new Error('INVALID_PASSWORD'));
        const req = { body: { email: 'a@cafe.com', password: 'wrong' } };
        const res = mockRes();
        await authController.login(req, res, next);
        expect(res.status).toHaveBeenCalledWith(401);
    });
});

describe('auth.controller - checkEmailExists', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu email', async () => {
        const req = { body: {} };
        const res = mockRes();
        await authController.checkEmailExists(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('trả 200 nếu email tồn tại', async () => {
        authService.checkEmailExists.mockResolvedValue({ exists: true });
        const req = { body: { email: 'a@cafe.com' } };
        const res = mockRes();
        await authController.checkEmailExists(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
    });

    test('trả 404 nếu email không tồn tại', async () => {
        authService.checkEmailExists.mockRejectedValue({ code: 'auth/user-not-found' });
        const req = { body: { email: 'none@cafe.com' } };
        const res = mockRes();
        await authController.checkEmailExists(req, res, next);
        expect(res.status).toHaveBeenCalledWith(404);
    });
});

describe('auth.controller - generateOTP', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('gửi OTP thành công, lưu mã ở server và KHÔNG trả mã về client', async () => {
        emailService.generateAndSendOTP.mockResolvedValue('12345678');
        otpService.storeOtp.mockResolvedValue();
        const req = { body: { toEmail: 'a@cafe.com' } };
        const res = mockRes();
        await authController.generateOTP(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(otpService.storeOtp).toHaveBeenCalledWith('a@cafe.com', '12345678');
        expect(res.json.mock.calls[0][0]).not.toHaveProperty('code');
    });
});

describe('auth.controller - verifyOTP', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu email hoặc code', async () => {
        const req = { body: { email: 'a@cafe.com' } };
        const res = mockRes();
        await authController.verifyOTP(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('mã đúng -> trả 200 kèm resetToken', async () => {
        otpService.verifyOtp.mockResolvedValue('reset-token-abc');
        const req = { body: { email: 'a@cafe.com', code: '12345678' } };
        const res = mockRes();
        await authController.verifyOTP(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.json.mock.calls[0][0]).toHaveProperty('resetToken', 'reset-token-abc');
    });

    test('mã sai -> trả đúng status lỗi từ service', async () => {
        otpService.verifyOtp.mockRejectedValue(Object.assign(new Error('Mã xác nhận không đúng.'), { status: 400 }));
        const req = { body: { email: 'a@cafe.com', code: '00000000' } };
        const res = mockRes();
        await authController.verifyOTP(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });
});

describe('auth.controller - updatePassword', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu field', async () => {
        const req = { body: { email: 'a@cafe.com', newPassword: 'Pass@1234' } };
        const res = mockRes();
        await authController.updatePassword(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('mật khẩu yếu -> 400 và KHÔNG tiêu reset-token', async () => {
        const req = { body: { email: 'a@cafe.com', newPassword: 'weak', resetToken: 'tok' } };
        const res = mockRes();
        await authController.updatePassword(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
        expect(otpService.consumeResetToken).not.toHaveBeenCalled();
        expect(authService.updatePassword).not.toHaveBeenCalled();
    });

    test('token hợp lệ + mật khẩu mạnh -> 200, tiêu token rồi đổi mật khẩu', async () => {
        otpService.consumeResetToken.mockResolvedValue();
        authService.updatePassword.mockResolvedValue();
        const req = { body: { email: 'a@cafe.com', newPassword: 'Pass@1234', resetToken: 'tok' } };
        const res = mockRes();
        await authController.updatePassword(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(otpService.consumeResetToken).toHaveBeenCalledWith('a@cafe.com', 'tok');
        expect(authService.updatePassword).toHaveBeenCalledWith('a@cafe.com', 'Pass@1234');
    });

    test('token không hợp lệ -> trả status lỗi từ service', async () => {
        otpService.consumeResetToken.mockRejectedValue(
            Object.assign(new Error('Token đặt lại mật khẩu không hợp lệ.'), { status: 403 }));
        const req = { body: { email: 'a@cafe.com', newPassword: 'Pass@1234', resetToken: 'bad' } };
        const res = mockRes();
        await authController.updatePassword(req, res, next);
        expect(res.status).toHaveBeenCalledWith(403);
        expect(authService.updatePassword).not.toHaveBeenCalled();
    });
});
