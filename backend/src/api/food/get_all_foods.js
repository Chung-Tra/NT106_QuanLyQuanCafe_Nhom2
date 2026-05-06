const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyAndGetUser } = require("../../middlewares/auth_middleware");

/**
 * API: get_all_foods
 */
exports.getAllFoods = onRequest(async (req, res) => {
    if (req.method !== "GET") return res.status(405).send({ message: "Method Not Allowed" });
    try {
        await verifyAndGetUser(req);
        const snapshot = await db.ref('mon_uong').once('value');
        return res.status(200).send(snapshot.val() || {});
    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
