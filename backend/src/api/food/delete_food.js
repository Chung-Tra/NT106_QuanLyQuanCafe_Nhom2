const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");
const { reorderSequence } = require("../../utils/reorder_helper");

/**
 * API: delete_food
 */
exports.deleteFood = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");
    try {
        await verifyManagerRole(req);
        const { foodId } = req.body;

        await db.ref(`mon_uong/${foodId}`).remove();
        await reorderSequence('mon_uong', 'mon_');

        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
