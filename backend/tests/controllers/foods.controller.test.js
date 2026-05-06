const { mockDb } = require('../helpers/mockFirebase');
const foodsController = require('../../src/controllers/foods.controller');

jest.mock('../../src/utils/reorder_helper', () => ({
    reorderSequence: jest.fn().mockResolvedValue(undefined),
}));

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('foods.controller - getAll', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('trả danh sách món ăn', async () => {
        mockDb.once.mockResolvedValue({
            val: () => ({
                mon_001: { ten_mon: 'Cà phê đen', gia: 25000 },
                mon_002: { ten_mon: 'Cà phê sữa', gia: 30000 },
            }),
        });

        const req = {};
        const res = mockRes();
        await foodsController.getAll(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        const data = res.json.mock.calls[0][0];
        expect(Object.keys(data)).toHaveLength(2);
    });

    test('trả {} nếu không có dữ liệu', async () => {
        mockDb.once.mockResolvedValue({ val: () => null });
        const req = {};
        const res = mockRes();
        await foodsController.getAll(req, res, next);
        expect(res.json).toHaveBeenCalledWith({});
    });
});

describe('foods.controller - add', () => {
    const next = jest.fn();

    beforeEach(() => jest.clearAllMocks());

    test('thêm món và trả 201 với foodId', async () => {
        mockDb.once.mockResolvedValue({ numChildren: () => 3 });
        mockDb.set.mockResolvedValue(undefined);

        const req = { body: { ten_mon: 'Trà sữa', gia: 40000 } };
        const res = mockRes();
        await foodsController.add(req, res, next);

        expect(res.status).toHaveBeenCalledWith(201);
        const result = res.json.mock.calls[0][0];
        expect(result.foodId).toBe('mon_004');
    });
});

describe('foods.controller - remove', () => {
    const next = jest.fn();
    const { reorderSequence } = require('../../src/utils/reorder_helper');

    beforeEach(() => jest.clearAllMocks());

    test('xóa món và gọi reorderSequence', async () => {
        mockDb.remove.mockResolvedValue(undefined);

        const req = { params: { id: 'mon_002' } };
        const res = mockRes();
        await foodsController.remove(req, res, next);

        expect(mockDb.remove).toHaveBeenCalled();
        expect(reorderSequence).toHaveBeenCalledWith('mon_uong', 'mon_');
        expect(res.status).toHaveBeenCalledWith(200);
    });
});
