const { db } = require('../config/firebase');
const { info } = require('../utils/logger');

exports.getAll = async (req, res, next) => {
    try {
        const snapshot = await db.ref('nhap_kho').once('value');
        res.status(200).json(snapshot.val() || {});
    } catch (err) {
        next(err);
    }
};

exports.add = async (req, res, next) => {
    try {
        const data = req.body;

        const snapshot = await db.ref('nhap_kho').once('value');
        const items = snapshot.val() || {};
        const maxNum = Object.keys(items).reduce((max, key) => {
            const num = parseInt(key.replace('nk_', '')) || 0;
            return num > max ? num : max;
        }, 0);
        const nextId = `nk_${(maxNum + 1).toString().padStart(3, '0')}`;

        // Tính thanh_tien từng mặt hàng và tổng phiếu
        let tongTien = 0;
        if (data.ds_nl) {
            Object.keys(data.ds_nl).forEach(key => {
                const item = data.ds_nl[key];
                item.thanh_tien = (item.gia_nhap || 0) * (item.so_luong || 0);
                tongTien += item.thanh_tien;
            });
        }
        data.thanh_tien = tongTien;

        await db.ref(`nhap_kho/${nextId}`).set(data);
        info('Inventory import added', { id: nextId, tongTien });
        res.status(201).json({ success: true, id: nextId });
    } catch (err) {
        next(err);
    }
};
