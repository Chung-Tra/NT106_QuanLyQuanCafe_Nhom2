const { onRequest } = require("firebase-functions/v2/https");
const axios = require('axios');
const { db, apiKeyParam } = require("../../config/firebase");

/**
 * API: login_employee
 * Đăng nhập nhân viên.
 */
exports.loginEmployee = onRequest(async (req, res) => {
    if (req.method !== 'POST') {
        return res.status(405).send('Method Not Allowed');
    }

    const { email, password } = req.body;
    const FIREBASE_API_KEY = apiKeyParam.value();

    try {
        const authResponse = await axios.post(
            `https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=${FIREBASE_API_KEY}`,
            { email: email, password: password, returnSecureToken: true }
        );

        const idToken = authResponse.data.idToken;
        
        const snapshot = await db.ref('nhan_vien')
                                 .orderByChild('email')
                                 .equalTo(email)
                                 .once('value');

        if (!snapshot.exists()) {
            return res.status(404).json({ message: "Employee data not found." });
        }

        const data = snapshot.val();
        const employeeId = Object.keys(data)[0]; 
        const employeeData = data[employeeId];
        employeeData.EmployeeId = employeeId;

        return res.status(200).json({
            token: idToken,
            user: employeeData
        });

    } catch (error) {
        const errorMessage = error.response?.data?.error?.message || error.message;
        return res.status(401).json({ error: errorMessage });
    }
});
