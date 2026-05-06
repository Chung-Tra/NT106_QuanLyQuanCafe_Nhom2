const { db } = require('../config/firebase');
const { info, warn } = require('../utils/logger');

exports.getAll = async (req, res, next) => {
    try {
        const snapshot = await db.ref('nguyen_lieu').once('value');
        res.status(200).json(snapshot.val() || {});
    } catch (err) {
        next(err);
    }
};

exports.add = async (req, res, next) => {
    try {
        const data = req.body;
        const snapshot = await db.ref('nguyen_lieu').once('value');
        const items = snapshot.val() || {};
        const maxNum = Object.keys(items).reduce((max, key) => {
            const num = parseInt(key.replace('nl_', '')) || 0;
            return num > max ? num : max;
        }, 0);
        const nextId = `nl_${(maxNum + 1).toString().padStart(3, '0')}`;

        await db.ref(`nguyen_lieu/${nextId}`).set(data);
        info('Ingredient added', { id: nextId });
        res.status(201).json({ success: true, id: nextId });
    } catch (err) {
        next(err);
    }
};

exports.update = async (req, res, next) => {
    try {
        const { id } = req.params;
        const updateData = req.body;
        await db.ref(`nguyen_lieu/${id}`).update(updateData);
        info('Ingredient updated', { id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};

exports.remove = async (req, res, next) => {
    try {
        const { id } = req.params;
        await db.ref(`nguyen_lieu/${id}`).remove();
        info('Ingredient deleted', { id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};
