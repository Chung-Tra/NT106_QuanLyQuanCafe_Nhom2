const crypto = require('crypto');
const { getBucket } = require('../config/firebase');
const { info } = require('../utils/logger');

/**
 * Tải ảnh lên Firebase Storage rồi trả về URL tải công khai.
 * Dùng download token của Firebase nên hoạt động cả khi bucket bật
 * Uniform bucket-level access (không cần makePublic/ACL).
 *
 * Body: multipart/form-data
 *   - file:   ảnh (bắt buộc)
 *   - folder: thư mục lưu (tùy chọn: "mon_uong", "avatar", ...)
 */
async function uploadImage(req, res, next) {
    try {
        if (!req.file) {
            return res.status(400).json({ error: 'Không có file được tải lên' });
        }

        const bucket = getBucket();
        const folder = String(req.body.folder || 'misc').replace(/[^a-zA-Z0-9_-]/g, '') || 'misc';
        const ext = (req.file.originalname.split('.').pop() || 'jpg').toLowerCase().replace(/[^a-z0-9]/g, '');
        const token = crypto.randomUUID();
        const objectPath = `${folder}/${Date.now()}_${crypto.randomBytes(4).toString('hex')}.${ext}`;

        const file = bucket.file(objectPath);
        await file.save(req.file.buffer, {
            resumable: false,
            metadata: {
                contentType: req.file.mimetype,
                metadata: { firebaseStorageDownloadTokens: token }
            }
        });

        const url = `https://firebasestorage.googleapis.com/v0/b/${bucket.name}` +
            `/o/${encodeURIComponent(objectPath)}?alt=media&token=${token}`;

        info('image uploaded', { objectPath });
        res.status(201).json({ success: true, url });
    } catch (err) {
        next(err);
    }
}

module.exports = { uploadImage };
