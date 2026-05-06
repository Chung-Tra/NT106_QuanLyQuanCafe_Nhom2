const { db } = require('../config/firebase');
const { info, warn } = require('../utils/logger');

exports.getHistory = async (req, res, next) => {
    try {
        const { roomId } = req.query;
        if (!roomId) {
            warn('getHistory: missing roomId', { ip: req.ip });
            return res.status(400).json({ error: 'Missing roomId' });
        }

        const snapshot = await db.ref(`tin_nhan/${roomId}`)
            .orderByChild('thoi_gian')
            .once('value');

        const history = [];
        snapshot.forEach(child => history.push(child.val()));
        info('Chat history fetched', { roomId, count: history.length });
        res.status(200).json(history);
    } catch (err) {
        next(err);
    }
};

exports.saveMessage = async (req, res, next) => {
    try {
        const { roomId, chatData } = req.body;
        if (!roomId || !chatData) {
            warn('saveMessage: missing roomId or chatData', { ip: req.ip });
            return res.status(400).json({ error: 'Missing roomId or chatData' });
        }

        const serverTime = Date.now();
        chatData.thoi_gian = serverTime;

        await db.ref(`tin_nhan/${roomId}/msg_${serverTime}`).set(chatData);
        info('Message saved', { roomId, sender: chatData.nguoi_gui });
        res.status(201).json({ success: true });
    } catch (err) {
        next(err);
    }
};
