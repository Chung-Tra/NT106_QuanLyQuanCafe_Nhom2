const { mockAuth, mockDb } = require('../helpers/mockFirebase');
const employeesController = require('../../src/controllers/employees.controller');

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('employees.controller - getAll', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('manager nhận toàn bộ danh sách', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({
                nv_001: { vai_tro: 'barista', email: 'a@cafe.com' },
                nv_002: { vai_tro: 'manager', email: 'mgr@cafe.com' },
            }),
        });

        const req = { user: { vai_tro: 'manager' } };
        const res = mockRes();
        await employeesController.getAll(req, res, next);

        expect(res.status).toHaveBeenCalledWith(200);
        const data = res.json.mock.calls[0][0];
        expect(Object.keys(data)).toHaveLength(2);
    });

    test('barista chỉ thấy manager và admin (để chat / liên hệ lãnh đạo)', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({
                nv_001: { vai_tro: 'barista', email: 'a@cafe.com' },
                nv_002: { vai_tro: 'manager', email: 'mgr@cafe.com' },
                nv_003: { vai_tro: 'admin', email: 'admin@cafe.com' },
            }),
        });

        const req = { user: { vai_tro: 'barista' } };
        const res = mockRes();
        await employeesController.getAll(req, res, next);

        const data = res.json.mock.calls[0][0];
        expect(Object.keys(data)).toHaveLength(2);
        const roles = Object.values(data).map((e) => e.vai_tro).sort();
        expect(roles).toEqual(['admin', 'manager']);
    });
});

describe('employees.controller - add', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu email hoặc password', async () => {
        const req = { body: { ho_ten: 'Nguyen A' } };
        const res = mockRes();
        await employeesController.add(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('thêm thành công và trả 201', async () => {
        mockAuth.createUser.mockResolvedValue({ uid: 'uid_abc' });
        mockDb.once.mockResolvedValue({
            val: () => ({ nv_001: {} }),
            numChildren: () => 1,
        });
        mockDb.child.mockReturnThis();
        mockDb.set.mockResolvedValue(undefined);

        const req = { body: { email: 'new@cafe.com', Password: 'Pass@1234', ho_ten: 'Nguyen B' } };
        const res = mockRes();
        await employeesController.add(req, res, next);
        expect(res.status).toHaveBeenCalledWith(201);
    });
});

describe('employees.controller - lock', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('khóa tài khoản thành công', async () => {
        mockDb.update.mockResolvedValue(undefined);
        mockAuth.updateUser.mockResolvedValue(undefined);

        const req = { params: { id: 'nv_001' }, body: { authUid: 'uid_001' } };
        const res = mockRes();
        await employeesController.lock(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
    });
});
