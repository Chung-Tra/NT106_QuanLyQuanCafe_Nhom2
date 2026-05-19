const router = require('express').Router();
const ctrl = require('../controllers/chat.controller');
const { verifyAndGetUser, verifyServerSecret } = require('../middlewares/auth.middleware');

// Client dùng JWT, ChatServer dùng X-Server-Secret
function verifyAny(req, res, next) {
    const authHeader = req.headers.authorization;
    if (authHeader && authHeader.startsWith('Bearer ')) {
        return verifyAndGetUser(req, res, next);
    }
    return verifyServerSecret(req, res, next);
}

router.get('/messages',  verifyAny, ctrl.getHistory);
router.post('/messages', verifyAny, ctrl.saveMessage);

module.exports = router;
