const { mockDb } = require('../helpers/mockFirebase');
const inventoryController = require('../../src/controllers/inventory.controller');

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('inventory.controller - add (phiếu nhập kho)', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('tính lại thanh_tien từng dòng + tổng phiếu ở server (không tin client)', async () => {
        mockDb.once.mockResolvedValue({ val: () => ({ nk_001: {} }) });

        const req = {
            body: {
                nhanvien_id: 'nv_006',
                ngay_nhap: 20260706,
                ds_nl: {
                    nl_001: { gia_nhap: 150000, so_luong: 10, thanh_tien: 999 }, // client gửi sai
                    nl_002: { gia_nhap: 28000, so_luong: 5 },
                },
            },
        };
        const res = mockRes();
        await inventoryController.add(req, res, next);

        expect(res.status).toHaveBeenCalledWith(201);
        expect(res.json.mock.calls[0][0].id).toBe('nk_002');
        // Server tự tính lại: 150000×10 + 28000×5
        expect(req.body.ds_nl.nl_001.thanh_tien).toBe(1500000);
        expect(req.body.ds_nl.nl_002.thanh_tien).toBe(140000);
        expect(req.body.thanh_tien).toBe(1640000);
    });

    test('CỘNG TỒN KHO nguyên liệu sau khi lưu phiếu (transaction từng nl_id)', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        const req = {
            body: {
                nhanvien_id: 'nv_006',
                ds_nl: {
                    nl_001: { gia_nhap: 150000, so_luong: 10 },
                    nl_002: { gia_nhap: 28000, so_luong: 5 },
                },
            },
        };
        await inventoryController.add(req, mockRes(), next);

        // 1 transaction cho mỗi nguyên liệu trong phiếu
        expect(mockDb.transaction).toHaveBeenCalledTimes(2);
        // Hàm updater cộng đúng số lượng vào tồn hiện có
        const updater1 = mockDb.transaction.mock.calls[0][0];
        expect(updater1(7)).toBe(17);      // tồn 7 + nhập 10
        expect(updater1(null)).toBe(10);   // node chưa có ton_kho -> khởi tạo = số nhập
        const updater2 = mockDb.transaction.mock.calls[1][0];
        expect(updater2(0)).toBe(5);
    });

    test('phiếu không có ds_nl → vẫn lưu, không đụng tồn kho', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });

        const res = mockRes();
        await inventoryController.add({ body: { nhanvien_id: 'nv_006' } }, res, next);

        expect(res.status).toHaveBeenCalledWith(201);
        expect(mockDb.transaction).not.toHaveBeenCalled();
    });
});
