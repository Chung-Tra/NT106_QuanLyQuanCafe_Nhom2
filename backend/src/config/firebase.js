const admin = require("firebase-admin");
const { defineString } = require('firebase-functions/params');

// Định nghĩa các biến môi trường (Environment Variables)
// Những giá trị này được lấy từ file .env khi chạy locally hoặc từ Firebase Secrets khi deploy
const apiKeyParam = defineString('API_KEY');
const appSecretParam = defineString('APP_SECRET_KEY');
const emailUserParam = defineString('EMAIL_USER');
const emailPassParam = defineString('EMAIL_PASS');

// Khởi tạo Admin SDK (Chỉ chạy 1 lần duy nhất)
if (admin.apps.length === 0) {
    admin.initializeApp();
}

module.exports = {
    admin,
    db: admin.database(),
    auth: admin.auth(),
    apiKeyParam,
    appSecretParam,
    emailUserParam,
    emailPassParam
};
