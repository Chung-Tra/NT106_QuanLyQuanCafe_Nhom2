const { mockAuth, mockDb } = require('../helpers/mockFirebase');
const { verifyAndGetUser, verifyManagerRole } = require('../../src/middlewares/auth.middleware');

const mockReq = (token, ip = '127.0.0.1') => ({
    headers: { authorization: token ? `Bearer ${token}` : undefined },
    ip,
});

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('auth.middleware - verifyAndGetUser', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('trả 401 nếu không có Authorization header', async () => {
        const req = mockReq(null);
        const res = mockRes();
        await verifyAndGetUser(req, res, next);
        expect(res.status).toHaveBeenCalledWith(401);
        expect(next).not.toHaveBeenCalled();
    });

    test('trả 401 nếu token không hợp lệ', async () => {
        mockAuth.verifyIdToken.mockRejectedValue(new Error('Invalid token'));
        const req = mockReq('bad-token');
        const res = mockRes();
        await verifyAndGetUser(req, res, next);
        expect(res.status).toHaveBeenCalledWith(401);
    });

    test('gọi next() nếu token hợp lệ và tìm được nhân viên', async () => {
        mockAuth.verifyIdToken.mockResolvedValue({ email: 'nv@cafe.com' });
        mockDb.once.mockResolvedValue({
            exists: () => true,
            val: () => ({ 'nv_001': { email: 'nv@cafe.com', vai_tro: 'barista' } }),
        });

        const req = mockReq('valid-token');
        const res = mockRes();
        await verifyAndGetUser(req, res, next);
        expect(next).toHaveBeenCalled();
        expect(req.user).toBeDefined();
    });
});

describe('auth.middleware - verifyManagerRole', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('trả 403 nếu role không phải manager/admin', async () => {
        mockAuth.verifyIdToken.mockResolvedValue({ email: 'nv@cafe.com' });
        mockDb.once.mockResolvedValue({
            exists: () => true,
            val: () => ({ 'nv_001': { email: 'nv@cafe.com', vai_tro: 'barista' } }),
        });

        const req = mockReq('valid-token');
        const res = mockRes();
        await verifyManagerRole(req, res, next);
        expect(res.status).toHaveBeenCalledWith(403);
        expect(next).not.toHaveBeenCalled();
    });

    test('gọi next() nếu role là manager', async () => {
        mockAuth.verifyIdToken.mockResolvedValue({ email: 'mgr@cafe.com' });
        mockDb.once.mockResolvedValue({
            exists: () => true,
            val: () => ({ 'nv_001': { email: 'mgr@cafe.com', vai_tro: 'manager' } }),
        });

        const req = mockReq('valid-token');
        const res = mockRes();
        await verifyManagerRole(req, res, next);
        expect(next).toHaveBeenCalled();
    });
});
