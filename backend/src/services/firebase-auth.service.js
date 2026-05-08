const axios = require('axios');
const { auth, db } = require('../config/firebase');

async function loginEmployee(email, password) {
    const apiKey = process.env.FIREBASE_API_KEY;
    const authResponse = await axios.post(
        `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`,
        { email, password, returnSecureToken: true }
    );

    const idToken = authResponse.data.idToken;

    const snapshot = await db.ref('nhan_vien')
        .orderByChild('email')
        .equalTo(email)
        .once('value');

    if (!snapshot.exists()) throw new Error('Employee data not found.');

    const data = snapshot.val();
    const employeeId = Object.keys(data)[0];
    const employeeData = data[employeeId];
    employeeData.EmployeeId = employeeId;

    return { token: idToken, user: employeeData };
}

async function checkEmailExists(email) {
    await auth.getUserByEmail(email);
    return { exists: true };
}

async function updatePassword(email, newPassword, secretKey) {
    const expected = process.env.APP_SECRET_KEY;
    if (!expected) {
        const err = new Error('Server chưa cấu hình APP_SECRET_KEY trong .env');
        err.status = 500;
        throw err;
    }
    if (secretKey !== expected) {
        const err = new Error(
            'secretKey không khớp APP_SECRET_KEY — đồng bộ App.config FirebaseSecretKey với backend .env và restart server',
        );
        err.status = 403;
        throw err;
    }
    const userRecord = await auth.getUserByEmail(email);
    await auth.updateUser(userRecord.uid, { password: newPassword });
}

module.exports = { loginEmployee, checkEmailExists, updatePassword };
