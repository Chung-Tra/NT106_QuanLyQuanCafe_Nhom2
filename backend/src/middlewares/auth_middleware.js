const { db, auth } = require("../config/firebase");

/**
 * Middleware: Xác thực người dùng.
 */
async function verifyAndGetUser(req) {
    const authHeader = req.headers.authorization;
    if (!authHeader || !authHeader.startsWith('Bearer ')) {
        throw new Error('Unauthorized');
    }

    const token = authHeader.split('Bearer ')[1];
    const decodedToken = await auth.verifyIdToken(token);
    const userEmail = decodedToken.email;

    const snapshot = await db.ref('nhan_vien')
                             .orderByChild('email')
                             .equalTo(userEmail)
                             .once('value');

    if (!snapshot.exists()) throw new Error('User not found');

    const data = snapshot.val();
    const employeeId = Object.keys(data)[0];
    const employeeData = data[employeeId];
    employeeData.EmployeeId = employeeId;

    return employeeData; 
}

async function verifyManagerRole(req) {
    const employeeData = await verifyAndGetUser(req);
    const userRole = (employeeData.vai_tro || "").toLowerCase();

    if (userRole !== 'manager' && userRole !== 'admin') {
        throw new Error('Forbidden'); 
    }

    return employeeData; 
}

module.exports = {
    verifyAndGetUser,
    verifyManagerRole
};
