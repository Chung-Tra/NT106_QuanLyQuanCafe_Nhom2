# Danh mục đầy đủ luồng nghiệp vụ Client

> Liệt kê **mọi luồng dữ liệu** của client WinForms, trích xuất trực tiếp từ code
> (mỗi màn hình → các lời gọi BUS → endpoint backend → node Firebase).
> Sơ đồ chi tiết từng luồng lõi (đăng nhập, OTP, chat, nhập kho…) xem [dataflow.md](dataflow.md).

**Mẫu chung của mọi luồng:**

```
GUI (UserControl/Dialog) → BUS (validate) → DAL (HTTP + Bearer token) → Backend Express → Firebase RTDB
```

- Các `*BUS` "mỏng" (TableBUS, OrderBUS, PaymentBUS… trong [`ResourceBUS.cs`](../client/BUS/ResourceBUS.cs))
  đi qua **generic CRUD** `/api/<resource>`; ánh xạ resource → node xem [api.md](api.md#generic-resources).
- Màn hình tải dữ liệu bằng `Task.Run` (không chặn UI); lưới nào cũng có nút 🔄 tải lại riêng (`DgvRefresh`).

---

## 1. Luồng xác thực (trước khi vào Dashboard)

| # | Luồng | Màn hình | Gọi | Endpoint |
|---|-------|----------|-----|----------|
| 1.1 | Đăng nhập | `Auth/Login` | `AuthBUS.LoginBUS` | `POST /auth/login` |
| 1.2 | Warm-up sau đăng nhập (làm nóng HTTP + cache NV) | `Auth/Login` | `EmployeeBUS.GetAllEmployeesAsync` | `GET /employees` |
| 1.3 | Ghi nhớ đăng nhập (mã hóa DPAPI, lưu máy local) | `Auth/Login` | — (ProtectedData, không qua mạng) | — |
| 1.4 | Quên mật khẩu — nhập email | `Auth/ConfirmEmail` | `EmailBUS.ProcessPasswordResetAsync` | `POST /auth/check-email` → `POST /auth/otp/generate` |
| 1.5 | Nhập OTP → nhận reset-token | `Auth/VerifyCode` | `EmailBUS.VerifyOtpAsync` (+ gửi lại mã) | `POST /auth/otp/verify` |
| 1.6 | Đặt mật khẩu mới | `Auth/ResetPassword` | `AuthBUS.HandlePasswordReset` | `PUT /auth/password` |

---

## 2. Vai trò Admin

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 2.1 | `ucDashboard_Admin` | Load KPI + 2 bảng + 2 biểu đồ (doanh thu, feedback) | `PaymentBUS/ExpenseBUS/LossBUS/FeedbackBUS/ParkingBUS.GetAll` | `thanh_toan, chi_phi, that_thoat, feedback, bai_xe` |
| 2.2 | `ucDashboard_Admin` | 4 nút "Chi tiết →" mở `MetricDetail` (cấu thành + theo tháng); 2 nút mở `ChartDetail` (cột 12 tháng) | như trên | như trên |
| 2.3 | `ucManagers_Admin` | Load danh sách Quản lý; duyệt/từ chối đơn xin nghỉ của Manager; xem nhật ký | `EmployeeBUS.GetAllEmployeesAsync`, `LeaveRequestBUS.GetAll/Update`, `AuditLogBUS.GetAll` | `nhan_vien, xin_nghi, nhat_ky` |
| 2.4 | `ucStaff_Manager` *(dùng chung)* | Xem/thêm/sửa/khóa/xóa NV; duyệt xin nghỉ; xem lương | `EmployeeBUS.*`, `LeaveRequestBUS.GetAll/Update`, `SalaryBUS.GetAll` | `nhan_vien, xin_nghi, luong` |
| 2.5 | `ucPayroll_Admin` | Load bảng lương (tính bằng `AppMath`); duyệt lương | `SalaryBUS.GetAll/Update`, `EmployeeBUS.GetAllEmployeesAsync` | `luong, nhan_vien` |
| 2.6 | `ucExpenses_Admin` | Load chi phí; thêm/sửa khoản chi | `ExpenseBUS.GetAll/Add/Update`, `EmployeeBUS.GetAllEmployeesAsync` | `chi_phi, nhan_vien` |
| 2.7 | `ucReport_Admin` | Chọn loại (Doanh thu/Lương/Kho/Feedback) → dựng bảng → xuất Excel/PDF (`GridExporter`) | `PaymentBUS/SalaryBUS/IngredientBUS/FeedbackBUS.GetAll`, `EmployeeBUS...` | `thanh_toan, luong, nguyen_lieu, feedback` |
| 2.8 | `ucFeedback_Admin` | Load feedback; đánh dấu xử lý; xóa | `FeedbackBUS.GetAll/Update/Delete` | `feedback` |
| 2.9 | `ucNotification_Admin` | Load thông báo hệ thống; đánh dấu đã đọc | `NotificationBUS.GetAll/Update`, `EmployeeBUS...` | `thong_bao, nhan_vien` |

---

## 3. Vai trò Manager

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 3.1 | `ucOverview_Manager` | Load tổng quan ca (doanh thu, feedback, thông báo) | `PaymentBUS/FeedbackBUS/NotificationBUS.GetAll` | `thanh_toan, feedback, thong_bao` |
| 3.2 | `ucProducts_Manager` | Load thực đơn + tồn kho + tổng thu/chi tháng | `FoodBUS.GetListFoods`, `IngredientBUS.GetAll`, `InventoryImportBUS.GetAllImports`, `PaymentBUS.GetAll` | `mon_uong, nguyen_lieu, nhap_kho, thanh_toan` |
| 3.3 | `ucProducts_Manager` | Thêm/sửa/xóa món (dialog `AddFood`/`EditFood`/`FoodDetail`); lọc theo tên+giá | `FoodBUS.AddFood/UpdateFood/DeleteFood` | `mon_uong` |
| 3.4 | `ucProducts_Manager` | Nút **Nhập kho** → `WarehouseManager` → `AddInventoryImport` (nhập tay / Excel) | `InventoryImportBUS.AddImport` | `nhap_kho` + cộng tồn `nguyen_lieu` |
| 3.5 | `ucProducts_Manager` | Nút **Xem Biểu Đồ** → `ChartDetail` Doanh thu vs Chi phí nhập 12 tháng | `PaymentBUS.GetAll`, `InventoryImportBUS.GetAllImports` | `thanh_toan, nhap_kho` |
| 3.6 | `ucOrders_Manager` | Load tình trạng bàn/bếp từ đơn đang xử lý; lọc theo trạng thái; sửa bàn | `OrderBUS.GetAll`, `TableBUS.GetAll`, `FoodBUS.GetListFoods` | `don_hang, ban, mon_uong` |
| 3.7 | `ucOrders_Manager` | Nút **Cập nhật** → dialog tick còn/hết hàng từng món | `FoodBUS.UpdateFood` | `mon_uong` |
| 3.8 | `ucSchedule_Manager` | Load lịch ca theo tuần + đơn xin nghỉ chồng lịch | `ScheduleBUS.GetAll`, `LeaveRequestBUS.GetAll` | `lich_lam_viec, xin_nghi` |
| 3.9 | `ucPromotion_Manager` | Load 3 tab khuyến mãi (happy hour/combo/voucher); thêm/sửa | `PromotionBUS.GetAll/Add/Update` | `khuyen_mai` |
| 3.10 | `ucLoss_Manager` | Load thất thoát; ghi nhận/sửa khoản hao hụt | `LossBUS.GetAll/Add/Update`, `EmployeeBUS...` | `that_thoat, nhan_vien` |
| 3.11 | `ucFeedback_Manager` | Load feedback; phản hồi khách (dialog `ReplyFeedback`) | `FeedbackBUS.GetAll/Update` | `feedback` |
| 3.12 | `ucNotification_Manager` | Xử lý thông báo; duyệt xin nghỉ; phân ca ngay trong màn | `LeaveRequestBUS.GetAll/Update`, `ScheduleBUS.GetAll/Add/Update`, `EmployeeBUS...` | `xin_nghi, lich_lam_viec, nhan_vien` |

---

## 4. Vai trò Order Staff

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 4.1 | `ucPOS_Order` | Load menu dạng thẻ + sơ đồ bàn + hóa đơn gần đây | `FoodBUS.GetListFoods` *(qua cache)*, `TableBUS.GetAll`, `OrderBUS.GetAll`, `PaymentBUS.GetAll` | `mon_uong, ban, don_hang, thanh_toan` |
| 4.2 | `ucPOS_Order` | Tạo đơn: chọn món → giỏ → chọn bàn → lưu đơn | `OrderBUS.Add`, `TableBUS.Update` (bàn → có khách) | `don_hang, ban` |
| 4.3 | `ucPOS_Order` + `PaymentDialog` | Thanh toán: tiền mặt / QR chuyển khoản (mã QR sinh bằng `Qr.cs`), tính tiền bằng `AppMath` | `PaymentBUS.Add`, `OrderBUS.Update` (hoàn thành), `TableBUS.Update` (trả bàn) | `thanh_toan, don_hang, ban` |
| 4.4 | `ucCRM_Order` | Load khách hàng; thêm/sửa hồ sơ khách | `CustomerBUS.GetAll/Add/Update` | `khach_hang` |
| 4.5 | `ucLoyalty_Order` | Tra cứu điểm theo SĐT; tích điểm (1đ/3.000đ — `AppMath`); đổi quà (delta âm) | `CustomerBUS.GetAll/Add/Update`, `PointLogBUS.GetAll/Add` | `khach_hang, diem_log` |
| 4.6 | `ucReservation_Order` | Load đặt bàn; tạo đặt bàn mới; đổi trạng thái (xác nhận/đã đến/hủy) | `ReservationBUS.GetAll/Add/Update` | `dat_ban` |
| 4.7 | `ucSelfOrder_Order` | Sinh QR đặt-tại-bàn cho từng bàn; theo dõi đơn khách tự đặt realtime (poll) | `TableBUS.GetAll`, `OrderBUS.GetAll/Add` | `ban, don_hang` |
| 4.8 | `ucCashManagement_Order` | Đối soát két: tổng thu tiền mặt trong ca từ thanh toán | `PaymentBUS.GetAll` | `thanh_toan` |

---

## 5. Vai trò Barista

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 5.1 | `ucKDS_Barista` | Load đơn chờ pha (KDS); tick hoàn thành từng món → cập nhật trạng thái chế biến | `OrderBUS.GetAll/Update`, `TableBUS.GetAll`, `FoodBUS.GetListFoods` | `don_hang, ban, mon_uong` |
| 5.2 | `ucRecipe_Barista` | Load công thức pha chế + định lượng; tìm kiếm | `RecipeBUS.GetAll` | `cong_thuc` |
| 5.3 | `ucAlert_Barista` | Load cảnh báo NL; gửi cảnh báo mới (đồng thời bắn notification cho Manager) | `WarningBUS.GetAll/Add`, `NotificationBUS.Add`, `EmployeeBUS...` | `canh_bao, thong_bao, nhan_vien` |

---

## 6. Vai trò Security

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 6.1 | `ucParking_Security` | Load bãi xe; ghi xe vào; ghi xe ra + tính phí | `ParkingBUS.GetAll/Add/Update` | `bai_xe` |
| 6.2 | `ucSOS_Security` | Nút SOS khẩn cấp + báo sự cố (dialog `ReportIncident`) → notification tới Manager | `IncidentBUS.GetAll/Add`, `NotificationBUS.Add`, `EmployeeBUS...` | `su_co, thong_bao, nhan_vien` |

---

## 7. Màn hình dùng chung (mọi role vận hành)

| # | Màn hình | Luồng | Gọi | Node |
|---|----------|-------|-----|------|
| 7.1 | `ucOverview_Staff` | Tổng quan ca cá nhân (giờ công, đơn nghỉ, thông báo) | `AttendanceBUS/LeaveRequestBUS/NotificationBUS.GetAll` | `cham_cong, xin_nghi, thong_bao` |
| 7.2 | `ucAttendanceHistory` | Lịch sử chấm công, lọc theo ngày, xuất báo cáo | `AttendanceBUS.GetAll` | `cham_cong` |
| 7.3 | `ucWorkTracking` | Điểm danh nhân viên (Admin/Manager) | `AttendanceBUS.GetAll` | `cham_cong` |
| 7.4 | `ucLeaveRequest` | Gửi đơn xin nghỉ; xem trạng thái duyệt | `LeaveRequestBUS.GetAll/Add` | `xin_nghi` |
| 7.5 | `ucShiftRegister` | Nhận ca trống; đăng ký đổi ca | `ShiftBUS.GetAll/Add/Update` | `dang_ky_ca` |
| 7.6 | `ucBroadcastCenter` | Xem broadcast; nút "Soạn" mở `SendBroadcast` (chọn người nhận từ ds NV) → ghi | `BroadcastBUS.GetAll/Add`; dialog: `EmployeeBUS...` | `thong_bao_chung, nhan_vien` |
| 7.7 | `ucAuditLog` | Xem nhật ký thao tác, lọc theo vai trò/thao tác/mọi trường | `AuditLogBUS.GetAll` | `nhat_ky` |
| 7.8 | `ucProfile` | Sửa hồ sơ; đổi avatar (upload ảnh); đổi mật khẩu (biết MK cũ); xem lịch tuần | `EmployeeBUS.UpdateEmployeeAsync/UpdateAvatarAsync`, `UploadBUS.UploadImage`, `AuthBUS.ChangePasswordBUS`, `ScheduleBUS.GetAll` | `nhan_vien`, Storage, `lich_lam_viec` |
| 7.9 | `ucInternalChat` | Chat realtime SignalR (gửi/nhận theo room, server tự lưu); tải lịch sử | `ChatManager.*`, `ChatBUS.GetHistory/GetRoomId` | `tin_nhan` (qua ChatServer) |

> Ghi âm thầm phía client: `Audit.Log(...)` trong BUS tự ghi thao tác Thêm/Sửa/Xóa vào `nhat_ky` (best-effort).

---

## 8. Luồng của Dialog

| # | Dialog | Mở từ | Luồng ghi dữ liệu |
|---|--------|-------|-------------------|
| 8.1 | `AddEmployee` | `ucStaff_Manager` / `ucManagers_Admin` | `EmployeeBUS.AddEmployeeAsync` → tạo Firebase Auth user + node `nhan_vien` |
| 8.2 | `EditEmployee` | ucStaff_Manager | `EmployeeBUS.UpdateEmployeeAsync` / `LockEmployeeAsync` |
| 8.3 | `EmployeeDetail` | ucStaff_Manager | Xem read-only; tùy chọn `DeleteEmployeeAsync` |
| 8.4 | `AddFood` / `EditFood` | ucProducts_Manager | `UploadBUS.UploadImage` (ảnh → Storage) → `FoodBUS.AddFood/UpdateFood` |
| 8.5 | `FoodDetail` | ucProducts_Manager | Xem chi tiết; tùy chọn `FoodBUS.DeleteFood` |
| 8.6 | `WarehouseManager` → `AddInventoryImport` | ucProducts_Manager | `InventoryImportBUS.GetIngredients/GetEmployees` (load) → `AddImport` (ghi) |
| 8.7 | `PaymentDialog` | ucPOS_Order | Nhận giỏ hàng → chọn phương thức → trả kết quả cho POS ghi `thanh_toan` |
| 8.8 | `SendBroadcast` | ucBroadcastCenter | Load ds NV chọn người nhận → trả DTO cho Center ghi `thong_bao_chung` |
| 8.9 | `ReplyFeedback` | ucFeedback_Manager | Trả nội dung phản hồi → `FeedbackBUS.Update` |
| 8.10 | `ReportIncident` | ucSOS_Security | `BugReportBUS.Add` (ghi nhận sự cố dạng báo cáo) |
| 8.11 | `ReportBug` | Sidebar (mọi role) | `BugReportBUS.Add` → `bao_loi` |
| 8.12 | `ChartDetail` / `MetricDetail` | Dashboard, Products | Chỉ hiển thị (nhận dữ liệu đã tải từ màn gọi) |
| 8.13 | `RecordDetail` / `RecordEdit` | Double-click mọi lưới | Xem/sửa 1 bản ghi tổng quát (RecordEdit ghi qua BUS tương ứng của màn gọi) |
| 8.14 | `AuditLogDetail`, `LeaveRequestDetail`, `ManagerProfileDetail` | các lưới liên quan | Xem chi tiết read-only (`ManagerProfileDetail` tải thêm `OrderBUS.GetAll` thống kê) |

---

## Ma trận BUS → endpoint → node (tra cứu nhanh)

| BUS | Endpoint | Node | Dùng bởi (màn chính) |
|-----|----------|------|----------------------|
| `AuthBUS` | `/auth/login`, `/auth/password`, `/auth/change-password` | Firebase Auth | Login, ResetPassword, Profile |
| `EmailBUS` | `/auth/check-email`, `/auth/otp/*` | — | ConfirmEmail, VerifyCode |
| `EmployeeBUS` | `/employees*` | `nhan_vien` | Staff, Managers, nhiều màn (tên NV) |
| `FoodBUS` | `/foods*` | `mon_uong` | Products, POS, KDS, Orders |
| `IngredientBUS` | `/ingredients*` | `nguyen_lieu` | Products, Report |
| `InventoryImportBUS` | `/inventory*` | `nhap_kho` | Products, WarehouseManager |
| `UploadBUS` | `/upload` | Firebase Storage | AddFood, EditFood, Profile |
| `ChatBUS` + `ChatManager` | `/chat/messages` + SignalR `/chathub` | `tin_nhan` | InternalChat |
| `TableBUS` | `/tables` | `ban` | POS, SelfOrder, KDS, Orders |
| `OrderBUS` | `/orders` | `don_hang` | POS, KDS, SelfOrder, Orders |
| `PaymentBUS` | `/payments` | `thanh_toan` | POS, Cash, Dashboard, Overview, Report |
| `CustomerBUS` | `/customers` | `khach_hang` | CRM, Loyalty |
| `PointLogBUS` | `/point-logs` | `diem_log` | Loyalty |
| `FeedbackBUS` | `/feedback` | `feedback` | Feedback (Admin/Manager), Dashboard |
| `AttendanceBUS` | `/attendance` | `cham_cong` | AttendanceHistory, WorkTracking, Overview_Staff |
| `SalaryBUS` | `/salaries` | `luong` | Payroll, Staff, Report |
| `LeaveRequestBUS` | `/leave-requests` | `xin_nghi` | LeaveRequest, Staff, Managers, Notification_Manager, Schedule |
| `NotificationBUS` | `/notifications` | `thong_bao` | Notification (Admin), Overview, SOS, Alert |
| `ParkingBUS` | `/parking` | `bai_xe` | Parking, Dashboard |
| `IncidentBUS` | `/incidents` | `su_co` | SOS |
| `WarningBUS` | `/warnings` | `canh_bao` | Alert_Barista |
| `RecipeBUS` | `/recipes` | `cong_thuc` | Recipe_Barista |
| `PromotionBUS` | `/promotions` | `khuyen_mai` | Promotion_Manager |
| `ExpenseBUS` | `/expenses` | `chi_phi` | Expenses_Admin, Dashboard |
| `LossBUS` | `/losses` | `that_thoat` | Loss_Manager, Dashboard |
| `ReservationBUS` | `/reservations` | `dat_ban` | Reservation_Order |
| `AuditLogBUS` | `/audit-logs` | `nhat_ky` | AuditLog, Managers_Admin |
| `BroadcastBUS` | `/broadcasts` | `thong_bao_chung` | BroadcastCenter |
| `ScheduleBUS` | `/schedules` | `lich_lam_viec` | Schedule, Notification_Manager, Profile |
| `ShiftBUS` | `/shift-registers` | `dang_ky_ca` | ShiftRegister |
| `BugReportBUS` | `/bug-reports` | `bao_loi` | ReportBug, ReportIncident |
