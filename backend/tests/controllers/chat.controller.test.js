const { mockDb } = require('../helpers/mockFirebase');
const chatController = require('../../src/controllers/chat.controller');

const mockRes = () => {
    const res = {};
    res.status = jest.fn().mockReturnValue(res);
    res.json = jest.fn().mockReturnValue(res);
    return res;
};

describe('chat.controller - getHistory', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu roomId', async () => {
        const req = { query: {}, ip: '127.0.0.1' };
        const res = mockRes();
        await chatController.getHistory(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('trả danh sách tin nhắn', async () => {
        const messages = [
            { noi_dung: 'Xin chào', thoi_gian: 1000 },
            { noi_dung: 'Có thể giúp gì không?', thoi_gian: 2000 },
        ];
        mockDb.once.mockResolvedValue({
            forEach: (cb) => messages.forEach(m => cb({ val: () => m })),
        });

        const req = { query: { roomId: 'room_001' }, ip: '127.0.0.1' };
        const res = mockRes();
        await chatController.getHistory(req, res, next);
        expect(res.status).toHaveBeenCalledWith(200);
        expect(res.json.mock.calls[0][0]).toHaveLength(2);
    });
});

describe('chat.controller - saveMessage', () => {
    const next = jest.fn();
    beforeEach(() => jest.clearAllMocks());

    test('trả 400 nếu thiếu roomId hoặc chatData', async () => {
        const req = { body: { roomId: 'room_001' }, ip: '127.0.0.1' };
        const res = mockRes();
        await chatController.saveMessage(req, res, next);
        expect(res.status).toHaveBeenCalledWith(400);
    });

    test('lưu tin nhắn thành công và trả 201', async () => {
        mockDb.set.mockResolvedValue(undefined);

        const req = {
            body: { roomId: 'room_001', chatData: { noi_dung: 'Hello', nguoi_gui: 'nv_001' } },
            ip: '127.0.0.1',
        };
        const res = mockRes();
        await chatController.saveMessage(req, res, next);
        expect(res.status).toHaveBeenCalledWith(201);
    });
});
