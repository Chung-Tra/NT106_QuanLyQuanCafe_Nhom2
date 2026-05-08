const { mockAuth } = require('../helpers/mockFirebase');

jest.mock('../../src/services/firebase-auth.service', () => ({
    loginEmployee: jest.fn(),
    checkEmailExists: jest.fn(),
    updatePassword: jest.fn(),
}));
jest.mock('../../src/services/email.service', () => ({
    generateAndSendOTP: jest.fn(),
}));

const authController = require('../../src/controllers/auth.controller');
const authService = require('../../src/services/firebase-auth.service');
const emailService = require('../../src/services/email.service');

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

    test('gửi OTP thành công', async () => {
        emailService.generateAndSendOTP.mockResolvedValue('123456');
        const req = { body: { toEmail: 'a@cafe.com' } };
        const res = mockRes();
        await authController.generateOTP(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.json.mock.calls[0][0]).toHaveProperty('code', '123456');
    });
});
