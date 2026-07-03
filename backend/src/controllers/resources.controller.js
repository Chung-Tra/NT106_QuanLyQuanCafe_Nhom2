const { db } = require('../config/firebase');
const { info } = require('../utils/logger');

/**
 * CRUD chung cho các node RTDB phẳng (ban, don_hang, thanh_toan, ...).
 * Cùng contract với foods.controller: GET trả nguyên object {id: {...}},
 * POST tự sinh id "prefixNNN" = max hiện có + 1.
 */
function makeResource(node, prefix) {
    const nextId = (val) => {
        let max = 0;
        for (const key of Object.keys(val || {})) {
            if (!key.startsWith(prefix)) continue;
            const n = parseInt(key.slice(prefix.length), 10);
            if (!Number.isNaN(n) && n > max) max = n;
        }
        return `${prefix}${(max + 1).toString().padStart(3, '0')}`;
    };

    return {
        getAll: async (req, res, next) => {
            try {
                const snapshot = await db.ref(node).once('value');
                res.status(200).json(snapshot.val() || {});
            } catch (err) { next(err); }
        },

        add: async (req, res, next) => {
            try {
                const snapshot = await db.ref(node).once('value');
                const id = nextId(snapshot.val());
                await db.ref(`${node}/${id}`).set(req.body);
                info(`${node} added`, { id });
                res.status(201).json({ success: true, id });
            } catch (err) { next(err); }
        },

        update: async (req, res, next) => {
            try {
                const { id } = req.params;
                const data = req.body;
                delete data.Id;
                await db.ref(`${node}/${id}`).update(data);
                info(`${node} updated`, { id });
                res.status(200).json({ success: true });
            } catch (err) { next(err); }
        },

        remove: async (req, res, next) => {
            try {
                const { id } = req.params;
                await db.ref(`${node}/${id}`).remove();
                info(`${node} deleted`, { id });
                res.status(200).json({ success: true });
            } catch (err) { next(err); }
        },
    };
}

module.exports = { makeResource };
