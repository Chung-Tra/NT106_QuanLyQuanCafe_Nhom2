const { onRequest } = require("firebase-functions/v2/https");
const { auth, appSecretParam } = require("../../config/firebase");

/**
 * API: update_password
 * Đổi mật khẩu nhân viên.
 */
exports.updateUserPassword = onRequest(async (req, res) => {
    if (req.method !== "POST") {
        return res.status(405).send("Method Not Allowed");
    }

    const { email, newPassword, secretKey } = req.body;
    const MY_PRIVATE_KEY = appSecretParam.value();

    if (secretKey !== MY_PRIVATE_KEY) {
        return res.status(403).send({ message: "Unauthorized" });
    }

    try {
        const userRecord = await auth.getUserByEmail(email);

        await auth.updateUser(userRecord.uid, {
            password: newPassword,
        });

        return res.status(200).send({ message: "Success" });
    } catch (error) {
        return res.status(500).send({ error: error.message });
    }
});
