const { onRequest } = require("firebase-functions/v2/https");
const { auth } = require("../../config/firebase");

/**
 * API: check_email_exists
 * Kiểm tra xem email đã tồn tại trong Firebase Auth chưa.
 */
exports.checkEmailExists = onRequest(async (req, res) => {
    if (req.method !== 'POST') {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    const { email } = req.body;
    if (!email) {
        return res.status(400).send({ message: "Missing email." });
    }

    try {
        // Sử dụng auth từ config
        await auth.getUserByEmail(email);
        
        return res.status(200).send({ exists: true, message: "Valid email address." });
    } catch (error) {
        if (error.code === 'auth/user-not-found') {
            return res.status(404).send({ exists: false, message: "Email address not found." });
        }
        console.error("Error checking email existence:", error);
        return res.status(500).send({ message: "Server error: " + error.message });
    }
});
