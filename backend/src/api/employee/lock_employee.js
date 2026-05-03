const { onRequest } = require("firebase-functions/v2/https");
const { auth, db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: lock_employee
 */
exports.lockEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");

    try {
        await verifyManagerRole(req);
        const { employeeId, authUid } = req.body;

        await db.ref(`nhan_vien/${employeeId}`).update({ trang_thai: "inactive" });
        await auth.updateUser(authUid, { disabled: true });

        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
