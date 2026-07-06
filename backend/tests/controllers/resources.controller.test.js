const { mockDb } = require('../helpers/mockFirebase');
const { makeResource } = require('../../src/controllers/resources.controller');

// Factory này đứng sau 23 endpoint generic (/tables, /orders, /payments, ...)
// nên chỉ cần test 1 instance là phủ hành vi của tất cả.
const ctrl = makeResource('ban', 'ban_');

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('resources.controller - getAll', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('trả nguyên object {id: {...}} của node', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({
                ban_001: { ten_ban: 'Bàn 1' },
                ban_002: { ten_ban: 'Bàn 2' },
            }),
        });

        const res = mockRes();
        await ctrl.getAll({}, res, next);

        expect(res.status).toHaveBeenCalledWith(200);
        expect(Object.keys(res.json.mock.calls[0][0])).toHaveLength(2);
    });

    test('node rỗng trả {} (không phải null)', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        const res = mockRes();
        await ctrl.getAll({}, res, next);

        expect(res.json).toHaveBeenCalledWith({});
    });

    test('lỗi DB được chuyển cho error middleware qua next()', async () => {
        mockDb.once.mockRejectedValue(new Error('offline'));

        const res = mockRes();
        await ctrl.getAll({}, res, next);

        expect(next).toHaveBeenCalledWith(expect.any(Error));
        expect(res.status).not.toHaveBeenCalled();
    });
});

describe('resources.controller - add (tự sinh id prefixNNN)', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('id mới = max hiện có + 1, đệm 3 chữ số', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({ ban_001: {}, ban_003: {} }),
        });

        const res = mockRes();
        await ctrl.add({ body: { ten_ban: 'Bàn mới' } }, res, next);

        expect(res.status).toHaveBeenCalledWith(201);
        expect(res.json.mock.calls[0][0]).toEqual({ success: true, id: 'ban_004' });
    });

    test('node rỗng → id đầu tiên là ban_001', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        const res = mockRes();
        await ctrl.add({ body: {} }, res, next);

        expect(res.json.mock.calls[0][0].id).toBe('ban_001');
    });

    test('bỏ qua key khác prefix và key hậu tố không thuần số (vd bản ghi seed ban_s001)', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({
                dh_099: {},      // node khác prefix -> bỏ qua
                ban_s001: {},    // id do script seed sinh -> parseInt('s001') = NaN -> bỏ qua
                ban_002: {},
            }),
        });

        const res = mockRes();
        await ctrl.add({ body: {} }, res, next);

        expect(res.json.mock.calls[0][0].id).toBe('ban_003');
    });
});

describe('resources.controller - update', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('cập nhật partial và loại field Id khỏi payload (Id chỉ là key, không phải data)', async () => {
        const res = mockRes();
        await ctrl.update(
            { params: { id: 'ban_002' }, body: { Id: 'ban_002', trang_thai: 'trong' } },
            res, next);

        expect(mockDb.update).toHaveBeenCalledWith({ trang_thai: 'trong' });
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.json).toHaveBeenCalledWith({ success: true });
    });
});

describe('resources.controller - remove', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('xóa đúng 1 bản ghi, không đọc lại cả node', async () => {
        const res = mockRes();
        await ctrl.remove({ params: { id: 'ban_002' } }, res, next);

        expect(mockDb.remove).toHaveBeenCalled();
        expect(mockDb.once).not.toHaveBeenCalled();
        expect(res.status).toHaveBeenCalledWith(200);
    });
});
