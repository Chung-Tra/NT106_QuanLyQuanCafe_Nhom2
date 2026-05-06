const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyAndGetUser } = require("../../middlewares/auth_middleware");

/**
 * API: save_message
 */
exports.saveChatMessage = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");
    try {
        await verifyAndGetUser(req);
        const { roomId, chatData } = req.body;

        const serverTime = Date.now();
        chatData.thoi_gian = serverTime; 

        await db.ref(`tin_nhan/${roomId}/msg_${serverTime}`).set(chatData);
        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
