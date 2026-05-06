const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: update_employee
 */
exports.updateEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send({ message: "Method Not Allowed" });

    try {
        await verifyManagerRole(req);

        const { employeeId, updateData } = req.body;
        if (!employeeId || !updateData) return res.status(400).send({ error: "Missing data" });

        delete updateData.AuthUid; 
        delete updateData.email;

        await db.ref(`nhan_vien/${employeeId}`).update(updateData);

        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
