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
    if (secretKey !== process.env.APP_SECRET_KEY) {
        const err = new Error('Unauthorized');
        err.status = 403;
        throw err;
    }
    const userRecord = await auth.getUserByEmail(email);
    await auth.updateUser(userRecord.uid, { password: newPassword });
}

module.exports = { loginEmployee, checkEmailExists, updatePassword };
