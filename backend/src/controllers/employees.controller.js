const { auth, db } = require('../config/firebase');
const { info } = require('../utils/logger');

exports.getAll = async (req, res, next) => {
    try {
        const snapshot = await db.ref('nhan_vien').once('value');
        const allEmployees = snapshot.val() || {};
        const role = (req.user.vai_tro || '').toLowerCase();

        if (role === 'manager' || role === 'admin') {
            return res.status(200).json(allEmployees);
        }

        // Nhân viên thường chỉ được xem nhóm lãnh đạo để nhắn chat (không có full danh sách đồng nghiệp).
        const leadersOnly = {};
        Object.entries(allEmployees).forEach(([key, emp]) => {
            const vt = (emp.vai_tro || '').toLowerCase();
            if (vt === 'manager' || vt === 'admin') {
                leadersOnly[key] = emp;
            }
        });
        res.status(200).json(leadersOnly);
    } catch (err) {
        next(err);
    }
};

exports.add = async (req, res, next) => {
    let createdUser = null;
    try {
        const employeeData = req.body;
        const email = (employeeData.email || '').trim();
        const password = (employeeData.Password || '').trim();
        if (!email || !password) return res.status(400).json({ error: 'Missing email or password' });

        createdUser = await auth.createUser({ email, password, displayName: employeeData.ho_ten });

        const ref = db.ref('nhan_vien');
        const snapshot = await ref.once('value');
        const employees = snapshot.val() || {};
        const maxIdNum = Object.keys(employees).reduce((max, key) => {
            const num = parseInt(key.replace('nv_', '')) || 0;
            return num > max ? num : max;
        }, 0);
        const nextId = `nv_${(maxIdNum + 1).toString().padStart(3, '0')}`;

        employeeData.trang_thai = 'active';
        employeeData.AuthUid = createdUser.uid;
        delete employeeData.Password;
        delete employeeData.password;

        await ref.child(nextId).set(employeeData);
        info('Employee added', { employeeId: nextId });
        res.status(201).json({ success: true, employeeId: nextId });
    } catch (err) {
        if (createdUser) await auth.deleteUser(createdUser.uid).catch(() => {});
        next(err);
    }
};

exports.update = async (req, res, next) => {
    try {
        const { id } = req.params;
        const updateData = req.body;
        delete updateData.AuthUid;
        delete updateData.email;

        await db.ref(`nhan_vien/${id}`).update(updateData);
        info('Employee updated', { employeeId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};

exports.remove = async (req, res, next) => {
    try {
        const { id } = req.params;
        const { authUid } = req.body;

        await auth.deleteUser(authUid);
        await db.ref(`nhan_vien/${id}`).remove();
        info('Employee deleted', { employeeId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};

exports.lock = async (req, res, next) => {
    try {
        const { id } = req.params;
        const { authUid } = req.body;

        await db.ref(`nhan_vien/${id}`).update({ trang_thai: 'inactive' });
        await auth.updateUser(authUid, { disabled: true });
        info('Employee locked', { employeeId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};
