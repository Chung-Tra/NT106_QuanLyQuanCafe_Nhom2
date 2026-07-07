const admin = require('firebase-admin');

let storageBucketName = process.env.FIREBASE_STORAGE_BUCKET;

if (admin.apps.length === 0) {
    if (process.env.FIREBASE_SERVICE_ACCOUNT_BASE64) {
        // Render / Railway / VPS: service account đưa qua env var
        // (base64 của serviceAccountKey.json — hosting ngoài GCP không có default credentials)
        const serviceAccount = JSON.parse(
            Buffer.from(process.env.FIREBASE_SERVICE_ACCOUNT_BASE64, 'base64').toString('utf8')
        );
        if (!storageBucketName && serviceAccount.project_id) {
            storageBucketName = `${serviceAccount.project_id}.appspot.com`;
        }
        admin.initializeApp({
            credential: admin.credential.cert(serviceAccount),
            databaseURL: process.env.FIREBASE_DATABASE_URL,
            storageBucket: storageBucketName
        });
    } else if (process.env.NODE_ENV === 'production') {
        // Cloud Run / Firebase Functions: dùng default credentials của GCP
        admin.initializeApp({
            databaseURL: process.env.FIREBASE_DATABASE_URL,
            storageBucket: storageBucketName
        });
    } else {
        // Local: dùng serviceAccountKey.json
        const serviceAccount = require('../../serviceAccountKey.json');
        // Nếu chưa cấu hình bucket qua .env, suy ra từ project_id
        if (!storageBucketName && serviceAccount.project_id) {
            storageBucketName = `${serviceAccount.project_id}.appspot.com`;
        }
        admin.initializeApp({
            credential: admin.credential.cert(serviceAccount),
            databaseURL: process.env.FIREBASE_DATABASE_URL,
            storageBucket: storageBucketName
        });
    }
}

/** Trả về Storage bucket mặc định (lazy). Ném lỗi rõ ràng nếu chưa cấu hình bucket. */
let _bucket = null;
function getBucket() {
    if (!_bucket) {
        if (!storageBucketName) {
            throw new Error('FIREBASE_STORAGE_BUCKET chưa được cấu hình (.env)');
        }
        _bucket = admin.storage().bucket();
    }
    return _bucket;
}

module.exports = {
    admin,
    db: admin.database(),
    auth: admin.auth(),
    getBucket
};
