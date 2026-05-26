const { onRequest } = require("firebase-functions/v2/https");
const { db } = require("../../config/firebase");

// SỬA QUAN TRỌNG: Đổi dấu gạch dưới (_) thành dấu chấm (.) ở chữ auth.middleware
const { verifyAndGetUser } = require("../../middlewares/auth.middleware");

/**
 * API: get_all_attendance
 * Lấy danh sách lịch sử chấm công (Phân quyền theo vai trò)
 */
exports.getAllAttendance = onRequest(async (req, res) => {
    // 1. Chỉ chấp nhận phương thức GET
    if (req.method !== "GET") {
        return res.status(405).send({ message: "Method Not Allowed" });
    }

    try {
        // 2. Xác thực người dùng qua token
        const requestUser = await verifyAndGetUser(req, res);
        
        // 3. Truy cập node 'cham_cong' trên Firebase
        const snapshot = await db.ref('cham_cong').once('value');
        const allAttendance = snapshot.val() || {};

        const userRole = (requestUser.vai_tro || "").toLowerCase();
        const userId = requestUser.nhanvien_id; // Giả sử middleware trả về id nhân viên đang đăng nhập

        // 4. Phân quyền trả về dữ liệu
        if (userRole === 'manager' || userRole === 'admin') {
            // Manager/Admin: Trả về toàn bộ danh sách chấm công
            return res.status(200).send(allAttendance);
        } else {
            // Nhân viên thường: Chỉ lọc ra những bản ghi chấm công của chính họ
            const myAttendanceOnly = {};
            Object.keys(allAttendance).forEach(key => {
                const record = allAttendance[key];
                if (record.nhanvien_id === userId) {
                    myAttendanceOnly[key] = record;
                }
            });
            return res.status(200).send(myAttendanceOnly);
        }

    } catch (error) {
        console.error("Error in getAllAttendance:", error);
        return res.status(403).send({ error: error.message });
    }
});
