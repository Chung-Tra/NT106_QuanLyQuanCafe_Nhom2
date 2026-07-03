const express = require('express');
const multer = require('multer');
const { verifyAndGetUser } = require('../middlewares/auth.middleware');
const { uploadImage } = require('../controllers/upload.controller');

const upload = multer({
    storage: multer.memoryStorage(),
    limits: { fileSize: 5 * 1024 * 1024 }, // 5 MB
    fileFilter: (req, file, cb) => {
        if (/^image\//.test(file.mimetype)) cb(null, true);
        else cb(new Error('Chỉ chấp nhận file ảnh (jpg, png, gif, webp...)'));
    }
});

const router = express.Router();

// POST /api/upload — bất kỳ nhân viên đã đăng nhập nào cũng tải ảnh được
router.post('/', verifyAndGetUser, upload.single('file'), uploadImage);

module.exports = router;
