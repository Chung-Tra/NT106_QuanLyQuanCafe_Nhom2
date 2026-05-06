const { onRequest } = require("firebase-functions/v2/https");
const { auth, db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: delete_employee
 */
exports.deleteEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") return res.status(405).send("Method Not Allowed");

    try {
        await verifyManagerRole(req);
        const { employeeId, authUid } = req.body;

        await auth.deleteUser(authUid);
        await db.ref(`nhan_vien/${employeeId}`).remove();

        return res.status(200).send({ success: true });
    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
