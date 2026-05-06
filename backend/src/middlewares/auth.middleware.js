const { auth, db } = require('../config/firebase');
const { warn } = require('../utils/logger');

async function _getEmployeeByEmail(email) {
    const snapshot = await db.ref('nhan_vien')
        .orderByChild('email')
        .equalTo(email)
        .once('value');

    if (!snapshot.exists()) throw new Error('User not found');

    const data = snapshot.val();
    const employeeId = Object.keys(data)[0];
    const employeeData = data[employeeId];
    employeeData.EmployeeId = employeeId;
    return employeeData;
}

async function verifyAndGetUser(req, res, next) {
    try {
        const authHeader = req.headers.authorization;
        if (!authHeader || !authHeader.startsWith('Bearer ')) {
            return res.status(401).json({ error: 'Unauthorized' });
        }

        const token = authHeader.split('Bearer ')[1];
        const decoded = await auth.verifyIdToken(token);
        const employee = await _getEmployeeByEmail(decoded.email);

        req.user = employee;
        next();
    } catch (err) {
        warn('Unauthorized access attempt', { ip: req.ip, error: err.message });
        return res.status(401).json({ error: 'Unauthorized' });
    }
}

async function verifyManagerRole(req, res, next) {
    await verifyAndGetUser(req, res, () => {
        const role = (req.user.vai_tro || '').toLowerCase();
        if (role !== 'manager' && role !== 'admin') {
            warn('Forbidden: insufficient role', { role, ip: req.ip });
            return res.status(403).json({ error: 'Forbidden' });
        }
        next();
    });
}

/**
 * Cho phép server nội bộ (ChatServer) gọi API không cần JWT.
 * Dùng header: X-Server-Secret: <APP_SECRET_KEY từ .env>
 */
function verifyServerSecret(req, res, next) {
    const secret = req.headers['x-server-secret'];
    if (secret && secret === process.env.APP_SECRET_KEY) {
        req.user = { EmployeeId: 'server', vai_tro: 'server' };
        return next();
    }
    return res.status(401).json({ error: 'Unauthorized' });
}

module.exports = { verifyAndGetUser, verifyManagerRole, verifyServerSecret };
