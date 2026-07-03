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

// Việc cho phép đổi mật khẩu đã được kiểm soát bằng reset-token (consumeResetToken)
// ở controller — nên ở đây chỉ thực thi đổi mật khẩu.
async function updatePassword(email, newPassword) {
    const userRecord = await auth.getUserByEmail(email);
    await auth.updateUser(userRecord.uid, { password: newPassword });
}

// Đổi mật khẩu khi đang đăng nhập: xác thực mật khẩu cũ trước, rồi đổi.
async function changePassword(email, oldPassword, newPassword) {
    const apiKey = process.env.FIREBASE_API_KEY;
    // Ném lỗi nếu mật khẩu cũ sai
    await axios.post(
        `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${apiKey}`,
        { email, password: oldPassword, returnSecureToken: false }
    );
    const userRecord = await auth.getUserByEmail(email);
    await auth.updateUser(userRecord.uid, { password: newPassword });
}

module.exports = { loginEmployee, checkEmailExists, updatePassword, changePassword };
