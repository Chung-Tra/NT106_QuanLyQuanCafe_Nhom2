const { onRequest } = require("firebase-functions/v2/https");
const { auth, db } = require("../../config/firebase");
const { verifyManagerRole } = require("../../middlewares/auth_middleware");

/**
 * API: add_employee
 * Thêm nhân viên mới.
 */
exports.addEmployee = onRequest(async (req, res) => {
    if (req.method !== "POST") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    let createdUser = null;

    try {
        await verifyManagerRole(req);

        const employeeData = req.body;
        const email = (employeeData.email || "").trim(); 
        const password = (employeeData.Password || "").trim(); 

        if (!email || !password) {
            return res.status(400).send({ error: "Missing Email or Password" });
        }

        createdUser = await auth.createUser({
            email,
            password,
            displayName: employeeData.ho_ten
        });

        const ref = db.ref('nhan_vien');
        const snapshot = await ref.once('value');
        const employees = snapshot.val() || {};

        let maxIdNum = 0;
        Object.keys(employees).forEach(key => {
            const num = parseInt(key.replace('nv_', ''));
            if (num > maxIdNum) maxIdNum = num;
        });

        const nextId = `nv_${(maxIdNum + 1).toString().padStart(3, '0')}`;
        
        employeeData.trang_thai = "active";
        employeeData.AuthUid = createdUser.uid; 
        delete employeeData.Password;
        delete employeeData.password;

        await ref.child(nextId).set(employeeData);

        return res.status(200).send({ success: true, employeeId: nextId });

    } catch (error) {
        if (createdUser) await auth.deleteUser(createdUser.uid);
        return res.status(400).send({ error: error.message });
    }
});
