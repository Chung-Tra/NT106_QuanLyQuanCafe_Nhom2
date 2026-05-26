const express = require('express');
const router = express.Router();
const attendanceApi = require('../api/attendance/get_all_attendance');

// Dùng ../ vì thư mục routes chỉ cách thư mục middlewares 1 cấp
// SỬA QUAN TRỌNG: Dùng dấu chấm (.)
const { verifyAndGetUser } = require('../middlewares/auth.middleware');

router.get('/all', //verifyAndGetUser, 
attendanceApi.getAllAttendance);

module.exports = router;