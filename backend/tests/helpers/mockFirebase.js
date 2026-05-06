/**
 * Mock Firebase Admin SDK để test không cần kết nối thật
 */

const mockDb = {
    _data: {},
    ref: jest.fn().mockReturnThis(),
    once: jest.fn(),
    set: jest.fn().mockResolvedValue(undefined),
    update: jest.fn().mockResolvedValue(undefined),
    remove: jest.fn().mockResolvedValue(undefined),
    child: jest.fn().mockReturnThis(),
    orderByChild: jest.fn().mockReturnThis(),
    equalTo: jest.fn().mockReturnThis(),
};

const mockAuth = {
    verifyIdToken: jest.fn(),
    createUser: jest.fn(),
    deleteUser: jest.fn().mockResolvedValue(undefined),
    updateUser: jest.fn().mockResolvedValue(undefined),
    getUserByEmail: jest.fn(),
};

jest.mock('../../src/config/firebase', () => ({
    db: mockDb,
    auth: mockAuth,
}));

module.exports = { mockDb, mockAuth };
