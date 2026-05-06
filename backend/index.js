// Wrapper dùng khi deploy lên Firebase Cloud Functions
// Chạy local thì dùng: npm run dev  (server.js)
// Deploy thì dùng: firebase deploy --only functions
require('dotenv').config();

const { onRequest } = require('firebase-functions/v2/https');
const app = require('./src/app');

exports.api = onRequest({ region: 'asia-southeast1' }, app);
