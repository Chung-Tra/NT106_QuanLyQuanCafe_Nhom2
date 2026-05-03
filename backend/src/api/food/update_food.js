const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: update_food
 */
exports.updateFood = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send({ message: "Method Not Allowed" });

    try {
        await verifyManagerRole(req);
        const { foodId, updateData } = req.body;

        if (updateData.Id) delete updateData.Id;
        await db.ref(`mon_uong/${foodId}`).update(updateData);

        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
