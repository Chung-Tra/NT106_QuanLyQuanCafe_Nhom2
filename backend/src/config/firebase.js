const admin = require('firebase-admin');

if (admin.apps.length === 0) {
    if (process.env.NODE_ENV === 'production') {
        // Cloud Run / Firebase Functions: dùng default credentials của GCP
        admin.initializeApp({
            databaseURL: process.env.FIREBASE_DATABASE_URL
        });
    } else {
        // Local: dùng serviceAccountKey.json
        const serviceAccount = require('../../serviceAccountKey.json');
        admin.initializeApp({
            credential: admin.credential.cert(serviceAccount),
            databaseURL: process.env.FIREBASE_DATABASE_URL
        });
    }
}

module.exports = {
    admin,
    db: admin.database(),
    auth: admin.auth()
};
