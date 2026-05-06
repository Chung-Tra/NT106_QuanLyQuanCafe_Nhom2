const { db } = require('../config/firebase');
const { reorderSequence } = require('../utils/reorder_helper');
const { info } = require('../utils/logger');

exports.getAll = async (req, res, next) => {
    try {
        const snapshot = await db.ref('mon_uong').once('value');
        res.status(200).json(snapshot.val() || {});
    } catch (err) {
        next(err);
    }
};

exports.add = async (req, res, next) => {
    try {
        const foodData = req.body;
        const snapshot = await db.ref('mon_uong').once('value');
        const count = snapshot.numChildren();
        const nextId = `mon_${(count + 1).toString().padStart(3, '0')}`;

        await db.ref(`mon_uong/${nextId}`).set(foodData);
        info('Food added', { foodId: nextId });
        res.status(201).json({ success: true, foodId: nextId });
    } catch (err) {
        next(err);
    }
};

exports.update = async (req, res, next) => {
    try {
        const { id } = req.params;
        const updateData = req.body;
        delete updateData.Id;

        await db.ref(`mon_uong/${id}`).update(updateData);
        info('Food updated', { foodId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};

exports.remove = async (req, res, next) => {
    try {
        const { id } = req.params;
        await db.ref(`mon_uong/${id}`).remove();
        await reorderSequence('mon_uong', 'mon_');
        info('Food deleted', { foodId: id });
        res.status(200).json({ success: true });
    } catch (err) {
        next(err);
    }
};
