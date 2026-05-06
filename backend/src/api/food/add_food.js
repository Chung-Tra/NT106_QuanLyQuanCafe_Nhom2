const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: add_food
 */
exports.addFood = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");
    try {
        await verifyManagerRole(req);
        const foodData = req.body;
        
        const snapshot = await db.ref('mon_uong').once('value');
        const count = snapshot.numChildren();
        const nextId = `mon_${(count + 1).toString().padStart(3, '0')}`;

        await db.ref(`mon_uong/${nextId}`).set(foodData);
        return res.status(200).send({ success: true, message: "Thành công" });
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
