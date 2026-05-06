const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyAndGetUser } = require("../../middlewares/auth_middleware");

/**
 * API: get_history
 */
exports.getChatHistory = onRequest(async (req, res) => {
    if (req.method !== "GET") return res.status(405).send({ message: "Method Not Allowed" });
    const { roomId } = req.query;
    try {
        await verifyAndGetUser(req);
        const snapshot = await db.ref(`tin_nhan/${roomId}`)
                                    .orderByChild("thoi_gian")
                                    .once("value");
        const history = [];
        snapshot.forEach((child) => {
            history.push(child.val());
        });
        return res.status(200).send(history);
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
