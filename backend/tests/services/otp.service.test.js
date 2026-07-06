// Chốt pepper TRƯỚC khi require service (service đọc APP_SECRET_KEY lúc load module)
process.env.APP_SECRET_KEY = 'test_pepper';

const crypto = require('crypto');
const { mockDb } = require('../helpers/mockFirebase');
const otp = require('../../src/services/otp.service');

// Tái tạo đúng hàm hash của service để dựng dữ liệu "đã lưu" trong test
const sha256 = (s) => crypto.createHash('sha256')
    .update(String(s) + process.env.APP_SECRET_KEY)
    .digest('hex');

const EMAIL = 'user@cafe.com';
const CODE = '12345678';

describe('otp.service - storeOtp', () => {
    beforeEach(() => jest.clearAllMocks());

    test('chỉ lưu HASH của mã (không bao giờ lưu mã thật) + hạn dùng + attempts=0', async () => {
        await otp.storeOtp(EMAIL, CODE);

        expect(mockDb.set).toHaveBeenCalledTimes(1);
        const saved = mockDb.set.mock.calls[0][0];
        expect(saved.codeHash).toBe(sha256(CODE));
        expect(saved.codeHash).not.toBe(CODE);
        expect(saved.attempts).toBe(0);
        expect(saved.expiresAt).toBeGreaterThan(Date.now());
    });
});

describe('otp.service - verifyOtp', () => {
    beforeEach(() => jest.clearAllMocks());

    const stored = (over = {}) => ({
        codeHash: sha256(CODE),
        expiresAt: Date.now() + 60_000,
        attempts: 0,
        ...over,
    });

    test('mã đúng → trả reset-token 64 hex và lưu HASH của token', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored() });

        const token = await otp.verifyOtp(EMAIL, CODE);

        expect(token).toMatch(/^[0-9a-f]{64}$/);
        const saved = mockDb.set.mock.calls[0][0];
        expect(saved.resetTokenHash).toBe(sha256(token));
        expect(saved.resetTokenHash).not.toBe(token);
    });

    test('mã sai → 400 và tăng bộ đếm attempts', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored() });

        await expect(otp.verifyOtp(EMAIL, '99999999'))
            .rejects.toMatchObject({ status: 400 });
        // child('attempts').set(1)
        expect(mockDb.set).toHaveBeenCalledWith(1);
    });

    test('mã hết hạn → 400 và xóa node', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored({ expiresAt: Date.now() - 1 }) });

        await expect(otp.verifyOtp(EMAIL, CODE))
            .rejects.toMatchObject({ status: 400 });
        expect(mockDb.remove).toHaveBeenCalled();
    });

    test('sai quá 5 lần → 429 và hủy mã (chặn brute-force)', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored({ attempts: 5 }) });

        await expect(otp.verifyOtp(EMAIL, CODE))
            .rejects.toMatchObject({ status: 429 });
        expect(mockDb.remove).toHaveBeenCalled();
    });

    test('chưa từng yêu cầu mã → 400', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        await expect(otp.verifyOtp(EMAIL, CODE))
            .rejects.toMatchObject({ status: 400 });
    });
});

describe('otp.service - consumeResetToken (dùng 1 lần)', () => {
    beforeEach(() => jest.clearAllMocks());

    const TOKEN = 'a'.repeat(64);
    const stored = (over = {}) => ({
        resetTokenHash: sha256(TOKEN),
        resetTokenExpiresAt: Date.now() + 60_000,
        ...over,
    });

    test('token hợp lệ → tiêu thụ và XÓA node (không dùng lại được)', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored() });

        await otp.consumeResetToken(EMAIL, TOKEN);

        expect(mockDb.remove).toHaveBeenCalled();
    });

    test('token sai → 403, node giữ nguyên', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored() });

        await expect(otp.consumeResetToken(EMAIL, 'b'.repeat(64)))
            .rejects.toMatchObject({ status: 403 });
        expect(mockDb.remove).not.toHaveBeenCalled();
    });

    test('token hết hạn → 403 và xóa node', async () => {
        mockDb.once.mockResolvedValue({ val: () => stored({ resetTokenExpiresAt: Date.now() - 1 }) });

        await expect(otp.consumeResetToken(EMAIL, TOKEN))
            .rejects.toMatchObject({ status: 403 });
        expect(mockDb.remove).toHaveBeenCalled();
    });

    test('chưa xác thực OTP (không có token) → 403', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        await expect(otp.consumeResetToken(EMAIL, TOKEN))
            .rejects.toMatchObject({ status: 403 });
    });
});
