const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");
const { verifyAndGetUser } = require("../../middlewares/auth_middleware");

/**
 * API: get_all_employees
 * Lấy danh sách nhân viên.
 */
exports.getAllEmployees = onRequest(async (req, res) => {
    if (req.method !== "GET") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    try {
        const requestUser = await verifyAndGetUser(req);
        
        const snapshot = await db.ref('nhan_vien').once('value');
        const allEmployees = snapshot.val() || {};

        const userRole = (requestUser.vai_tro || "").toLowerCase();

        if (userRole === 'manager' || userRole === 'admin') {
            return res.status(200).send(allEmployees);
        } else {
            const managersOnly = {};
            Object.keys(allEmployees).forEach(key => {
                const emp = allEmployees[key];
                if ((emp.vai_tro || "").toLowerCase() === 'manager') {
                    managersOnly[key] = emp;
                }
            });
            return res.status(200).send(managersOnly);
        }

    } catch (error) {
        return res.status(403).send({ error: error.message });
    }
});
