const { db } = require('../config/firebase');
const { info, warn } = require('../utils/logger');

exports.getHistory = async (req, res, next) => {
    try {
        const { roomId } = req.query;
        if (!roomId) {
            warn('getHistory: missing roomId', { ip: req.ip });
            return res.status(400).json({ error: 'Missing roomId' });
        }

        // Không dùng orderByChild('thoi_gian'): Firebase chỉ trả node *có* field đó —
        // tin cũ (thiếu thoi_gian hoặc schema khác) vẫn nằm DB nhưng bị "mất" trong query.
        const snapshot = await db.ref(`tin_nhan/${roomId}`).once('value');

        const history = [];
        snapshot.forEach((child) => {
            const val = child.val();
            if (val && typeof val === 'object' && !Array.isArray(val)) {
                history.push(val);
            }
        });
        history.sort((a, b) => {
            const ta = Number(a.thoi_gian ?? a.timestamp ?? 0);
            const tb = Number(b.thoi_gian ?? b.timestamp ?? 0);
            return ta - tb;
        });
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

        // Chuẩn hóa theo Firebase schema (tin_nhan): nguoi_gui_id, noi_dung, thoi_gian
        const serverTime = Date.now();
        const ts = Number(chatData.timestamp ?? chatData.thoi_gian) || serverTime;
        const payload = {
            nguoi_gui_id:  chatData.nguoi_gui_id  ?? chatData.senderId   ?? '',
            ten_nguoi_gui: chatData.ten_nguoi_gui ?? chatData.senderName  ?? '',
            noi_dung:      chatData.noi_dung      ?? chatData.message     ?? '',
            thoi_gian:     ts,
            loai_tin_nhan: chatData.loai_tin_nhan || 'text',
        };

        // Khóa Firebase: dùng thời điểm ghi để tránh trùng (trường `thoi_gian` vẫn là của client khi có)
        await db.ref(`tin_nhan/${roomId}/msg_${serverTime}`).set(payload);
        info('Message saved', { roomId, sender: payload.nguoi_gui_id });
        res.status(201).json({ success: true });
    } catch (err) {
        next(err);
    }
};
