# Hướng dẫn các Form / UserControl trong Dashboard

> Mỗi vai trò (role) sẽ có một danh sách menu riêng trong `MainDashboard`.
> Thứ tự menu thống nhất: **Tổng quan → Công việc chính → Báo cáo / Thông báo → Tiện ích (chat, xin nghỉ, lịch sử) → Profile / Cài đặt**.

---

## 1. Form dùng chung (Shared)


| File                     | Dùng cho        | Mô tả                                                           |
| ------------------------ | --------------- | --------------------------------------------------------------- |
| `ucProfile.cs`           | Tất cả role     | Xem/sửa thông tin cá nhân, đổi avatar, đổi mật khẩu.            |
| `ucInternalChat.cs`      | Tất cả role     | Chat nội bộ thời gian thực (SignalR) — chia phòng theo bộ phận. |
| `ucLeaveRequest.cs`      | Tất cả role     | Tạo / xem trạng thái đơn xin nghỉ phép.                         |
| `ucWorkTracking.cs`      | Admin / Manager | Điểm danh nhân viên (chấm công vào/ra).                         |
| `ucAttendanceHistory.cs` | NV vận hành     | Lịch sử chấm công cá nhân, có filter theo ngày + xuất báo cáo.  |
| `ucBroadcastCenter.cs`   | Admin / Manager | Trung tâm phát thông báo nội bộ tới tất cả NV hoặc cá nhân.     |
| `ucAuditLog.cs`          | Admin / Manager | Nhật ký thao tác hệ thống (`/nhat_ky`), lọc theo vai trò/thao tác. |
| `ucShiftRegister.cs`     | NV vận hành     | Chọn ca trống / đăng ký đổi ca (`/dang_ky_ca`).                 |
| `ucOverview_Staff.cs`    | NV vận hành     | Tổng quan ca cá nhân (Order/Barista/Security dùng chung).       |


---

## 2. Vai trò **Admin** (toàn quyền)


| Nhóm | Menu | UserControl | Chức năng |
| ---- | ---- | ----------- | --------- |
| CHÍNH | Tổng quan | `ucDashboard_Admin` | Doanh thu toàn quán, biểu đồ cột/đường, KPIs. |
| CHÍNH | Quản lý | `ucManagers_Admin` | Danh sách Manager (thêm, khóa, phân quyền). |
| CHÍNH | Nhân viên | `ucStaff_Manager` | Toàn bộ NV, thêm/sửa/khóa tài khoản. |
| CHÍNH | Tiền lương | `ucPayroll_Admin` | Bảng lương tự tính theo công + thưởng. |
| CHÍNH | Tiền chi | `ucExpenses_Admin` | Chi phí vận hành chi tiết (`/chi_phi`). |
| CHÍNH | Xuất báo cáo | `ucReport_Admin` | Xuất báo cáo Excel / PDF. |
| KHÁCH HÀNG | Feedback | `ucFeedback_Admin` | Tổng hợp feedback, gắn cờ feedback xấu. |
| KHÁCH HÀNG | Thông báo | `ucNotification_Admin` | Danh sách notification hệ thống. |
| KHÁCH HÀNG | Gửi thông báo | `ucBroadcastCenter` | Soạn & gửi broadcast nội bộ. |
| CÁ NHÂN | Điểm danh | `ucAttendanceHistory` | Điểm danh / lịch sử chấm công. |
| CÁ NHÂN | Nhật ký | `ucAuditLog` | Nhật ký thao tác hệ thống. |
| CÁ NHÂN | Chat nội bộ | `ucInternalChat` | Chat với toàn bộ nhân viên. |
| CÁ NHÂN | Hồ sơ cá nhân | `ucProfile` | Thông tin cá nhân. |


---

## 3. Vai trò **Manager** (quản lý ca)


| Nhóm | Menu | UserControl | Chức năng |
| ---- | ---- | ----------- | --------- |
| CHÍNH | Tổng quan | `ucOverview_Manager` | Tổng quan ca làm: doanh thu, đơn hàng, NV trực. |
| CHÍNH | Sản phẩm & Thực đơn | `ucProducts_Manager` | Quản lý món + tồn kho; nút **Nhập kho** mở `WarehouseManager` (phiếu nhập tay / điền từ Excel → `AddInventoryImport`). Nút **Xem Biểu Đồ** mở biểu đồ Doanh thu vs Chi phí nhập theo tháng. |
| CHÍNH | Đơn hàng & Hóa đơn | `ucOrders_Manager` | Tình trạng bàn/bếp; nút **Cập nhật** quản lý món còn/hết hàng. |
| CHÍNH | Nhân viên | `ucStaff_Manager` | Danh sách NV thuộc ca quản lý. |
| CHÍNH | Lịch ca làm | `ucSchedule_Manager` | Phân ca theo tuần (`/lich_lam_viec`). |
| CHÍNH | Khuyến mãi | `ucPromotion_Manager` | Happy hour / combo / voucher (`/khuyen_mai`). |
| CHÍNH | Thất thoát | `ucLoss_Manager` | Theo dõi hao hụt, biểu đồ xu hướng (`/that_thoat`). |
| KHÁCH HÀNG | Feedback | `ucFeedback_Manager` | Đọc & phản hồi feedback của khách. |
| KHÁCH HÀNG | Thông báo | `ucNotification_Manager` | Xử lý thông báo (SOS, cảnh báo NL). |
| KHÁCH HÀNG | Gửi thông báo | `ucBroadcastCenter` | Phát thông báo cho ca làm. |
| CÁ NHÂN | Xin nghỉ | `ucLeaveRequest` | Duyệt đơn xin nghỉ NV. |
| CÁ NHÂN | Điểm danh | `ucWorkTracking` | Chấm công vào/ra. |
| CÁ NHÂN | Nhật ký | `ucAuditLog` | Nhật ký thao tác hệ thống. |
| CÁ NHÂN | Chat nội bộ | `ucInternalChat` | Chat. |
| CÁ NHÂN | Hồ sơ cá nhân | `ucProfile` | Thông tin cá nhân. |


---

## 4. Vai trò **Order Staff** (NV order tại quầy)


| Nhóm | Menu | UserControl | Chức năng |
| ---- | ---- | ----------- | --------- |
| CHÍNH | Tổng quan | `ucOverview_Staff` | Tổng quan ca cá nhân: số order, hoa hồng. |
| CHÍNH | Lên đơn / POS | `ucPOS_Order` | Màn hình POS — chọn món, in bill, thanh toán. |
| CHÍNH | Khách hàng (CRM) | `ucCRM_Order` | Quản lý khách thân thiết (`/khach_hang`). |
| CHÍNH | Tích điểm | `ucLoyalty_Order` | Tích / đổi điểm & hạng thành viên (`/diem_log`). |
| CHÍNH | Đặt bàn | `ucReservation_Order` | Quản lý đặt bàn trước (`/dat_ban`). |
| CHÍNH | Đặt tại bàn QR | `ucSelfOrder_Order` | Đơn khách tự đặt qua QR, cập nhật realtime. |
| CHÍNH | Tiền mặt | `ucCashManagement_Order` | Két tiền mặt: nhập đầu ca/cuối ca, đối soát. |
| CÁ NHÂN | Lịch sử chấm công | `ucAttendanceHistory` | Xem giờ làm, ngày làm. |
| CÁ NHÂN | Xin nghỉ | `ucLeaveRequest` | Đăng ký nghỉ phép. |
| CÁ NHÂN | Chọn ca / Đổi ca | `ucShiftRegister` | Chọn ca trống / đăng ký đổi ca. |
| CÁ NHÂN | Chat nội bộ | `ucInternalChat` | Chat. |
| CÁ NHÂN | Hồ sơ cá nhân | `ucProfile` | Thông tin cá nhân. |


---

## 5. Vai trò **Barista** (NV pha chế)


| Nhóm | Menu | UserControl | Chức năng |
| ---- | ---- | ----------- | --------- |
| CHÍNH | Tổng quan | `ucOverview_Staff` | Tổng quan ca cá nhân. |
| CHÍNH | Màn hình Bếp | `ucKDS_Barista` | Order chờ pha realtime, tick xong từng món. |
| CHÍNH | Công thức pha chế | `ucRecipe_Barista` | Công thức + định lượng từng món (`/cong_thuc`). |
| CHÍNH | Cảnh báo NL | `ucAlert_Barista` | Cảnh báo nguyên liệu sắp hết (`/canh_bao`). |
| CÁ NHÂN | Lịch sử chấm công | `ucAttendanceHistory` | Xem lịch sử chấm công. |
| CÁ NHÂN | Xin nghỉ | `ucLeaveRequest` | Đăng ký nghỉ phép. |
| CÁ NHÂN | Chọn ca / Đổi ca | `ucShiftRegister` | Chọn ca trống / đăng ký đổi ca. |
| CÁ NHÂN | Chat nội bộ | `ucInternalChat` | Chat. |
| CÁ NHÂN | Hồ sơ cá nhân | `ucProfile` | Thông tin cá nhân. |


---

## 6. Module **Kho** (dialog trong `GUI/Dialogs/`)

> Không có role đăng nhập “thủ kho” riêng, cũng **không còn** thư mục `GUI/Warehouse/`.
> Nghiệp vụ kho được nhúng vào màn **Sản phẩm & Thực đơn** của **Manager**
> ([`ucProducts_Manager`](../client/GUI/Manager/ucProducts_Manager.cs)): lưới bên phải hiển thị tồn kho
> nguyên liệu (`IngredientBUS.GetAll`), nút **Nhập kho** mở dialog quản lý phiếu nhập.

| Thành phần | File | Ý nghĩa nghiệp vụ |
| ---------- | ---- | ----------------- |
| `WarehouseManager` | [`GUI/Dialogs/WarehouseManager.cs`](../client/GUI/Dialogs/WarehouseManager.cs) | Dialog xem/thêm phiếu nhập kho, cập nhật tồn nguyên liệu. |
| `AddInventoryImport` | [`GUI/Dialogs/AddInventoryImport.cs`](../client/GUI/Dialogs/AddInventoryImport.cs) | Form nhập chi tiết 1 phiếu (chọn NL, số lượng, giá, ghi chú). |
| `InventoryImportExcelReader` | [`GUI/Helpers/InventoryImportExcelReader.cs`](../client/GUI/Helpers/InventoryImportExcelReader.cs) | Đọc file Excel để prefill dòng phiếu nhập. |

Dữ liệu ghi vào node `/nhap_kho` (qua `/api/inventory`) và `/nguyen_lieu` (qua `/api/ingredients`).

---

## 7. Vai trò **Security** (Bảo vệ)


| Nhóm | Menu | UserControl | Chức năng |
| ---- | ---- | ----------- | --------- |
| CHÍNH | Tổng quan | `ucOverview_Staff` | Tổng quan ca cá nhân. |
| CHÍNH | Bãi xe | `ucParking_Security` | Quản lý xe vào/ra, biển số, phí gửi (`/bai_xe`). |
| CHÍNH | SOS An ninh | `ucSOS_Security` | Nút khẩn cấp + log sự cố an ninh (`/su_co`). |
| CÁ NHÂN | Lịch sử chấm công | `ucAttendanceHistory` | Xem lịch sử chấm công. |
| CÁ NHÂN | Xin nghỉ | `ucLeaveRequest` | Đăng ký nghỉ phép. |
| CÁ NHÂN | Chọn ca / Đổi ca | `ucShiftRegister` | Chọn ca trống / đăng ký đổi ca. |
| CÁ NHÂN | Chat nội bộ | `ucInternalChat` | Chat. |
| CÁ NHÂN | Hồ sơ cá nhân | `ucProfile` | Thông tin cá nhân. |


---

## 8. Dialog (form bật ra khi cần)


| File | Mở từ | Chức năng |
| ---- | ----- | --------- |
| `Auth/Login.cs` | App khởi động | Đăng nhập nhân viên. |
| `Auth/ConfirmEmail.cs` | `Login` (Quên mật khẩu) | Nhập email để nhận OTP. |
| `Auth/VerifyCode.cs` | `ConfirmEmail` | Nhập mã OTP 8 số → nhận reset-token. |
| `Auth/ResetPassword.cs` | `VerifyCode` | Đặt mật khẩu mới bằng reset-token. |
| `Dialogs/AddEmployee.cs` | `ucStaff_Manager` / `ucManagers_Admin` | Thêm nhân viên (tạo cả tài khoản Firebase Auth). |
| `Dialogs/EditEmployee.cs` | `ucStaff_Manager` | Sửa thông tin nhân viên. |
| `Dialogs/EmployeeDetail.cs` | `ucStaff_Manager` | Chi tiết nhân viên (read-only). |
| `Dialogs/AddFood.cs` | `ucProducts_Manager` | Thêm món mới (upload ảnh qua `/api/upload`). |
| `Dialogs/EditFood.cs` | `ucProducts_Manager` | Sửa món. |
| `Dialogs/FoodDetail.cs` | `ucProducts_Manager` | Chi tiết món + tùy chọn xóa. |
| `Dialogs/WarehouseManager.cs` | `ucProducts_Manager` (nút «Nhập kho») | Hub phiếu nhập kho; mở `AddInventoryImport`. |
| `Dialogs/AddInventoryImport.cs` | `WarehouseManager` | Tạo phiếu nhập kho (NV, ngày, chi tiết NL + SL + đơn giá; điền từ Excel). |
| `Dialogs/PaymentDialog.cs` | `ucPOS_Order` | Thanh toán hóa đơn (tiền mặt / chuyển khoản QR). |
| `Dialogs/SendBroadcast.cs` | `ucBroadcastCenter` | Soạn & gửi 1 thông báo broadcast. |
| `Dialogs/ReplyFeedback.cs` | `ucFeedback_Manager` | Phản hồi feedback của khách. |
| `Dialogs/ReportIncident.cs` | `ucSOS_Security` | Báo cáo sự cố an ninh. |
| `Dialogs/ReportBug.cs` | Sidebar | Báo lỗi / góp ý (`/bao_loi`). |
| `Dialogs/ChartDetail.cs` | Dashboard / Manager | Biểu đồ cột 12 tháng có bộ chọn khoảng tháng. |
| `Dialogs/MetricDetail.cs` | `ucDashboard_Admin` | Chi tiết một chỉ số (cấu thành + biểu đồ theo tháng). |
| `Dialogs/RecordDetail.cs` · `RecordEdit.cs` | Nhiều lưới (double-click) | Xem/sửa 1 bản ghi tổng quát. |
| `Common/InputDialog.cs` | Nhiều nơi | Hộp nhập 1 dòng theo theme app. |


---

## Quy ước UI

- **Theme**: Dark (`#252526` background, `#2D2D30` panel, `#1E1E1E` header).
- **Accent**: SteelBlue cho action chính, MediumSeaGreen cho thành công, IndianRed cho cảnh báo/nguy hiểm.
- **Font**: Segoe UI - title 13-16pt bold, body 9.5-10pt.
- **Tooltip**: mỗi nút sidebar có tooltip giải thích chức năng (ví dụ "Đơn hàng và Hóa đơn" → "Đơn hàng và Hóa đơn").

### MsgBox và dialog (modal)

- **Luôn dùng** `MsgBox.Show` (custom `GUI/Common/MsgBox.cs`), **không** dùng `MessageBox.Show` của WinForms để giữ theme bo góc / màu theo loại (Info / Success / Error / Warning).
- **Owner (neo cửa sổ cha)**  
  - Trong **UserControl** (hầu hết `uc*.cs`): gọi  
    `MsgBox.Show(MsgBox.OwnerWindow(this), "nội dung", "tiêu đề", loại)`  
    hoặc `MsgBox.OwnerWindow(control)` khi có biến control (ví dụ `ChatManager` với control chat).  
  - `OwnerWindow` = `FindForm()` **hoặc** `TopLevelControl` (fallback khi control nằm sâu trong `Panel` / layout).  
  - Trong **Form** độc lập (`Login`, `VerifyCode`, …): có thể truyền thẳng `this` vì `Form` là `IWin32Window`.
- **Nội dung nhiều dòng**: trong code gõ xuống dòng bằng `\n` trong chuỗi; `MsgBox` chuẩn hóa sang CRLF khi gán vào `TextBox` để hiển thị đúng trên Windows.
- **Chiều cao & cuộn**: `LayoutForContent` dùng `DialogAutosizeHelper.SetWrappedTextBoxHeight` — nội dung dài thì ô tin nhắn có **thanh cuộn dọc**; một số form chi tiết dài có thể **cuộn cả form** (qua `DialogAutosizeHelper.CapFormHeightWithAutoScroll` nơi áp dụng).
- **Dialog `ShowDialog`**: mở form con từ UC dùng cùng owner, ví dụ  
  `someForm.ShowDialog(MsgBox.OwnerWindow(this))`  
  để modal nằm đúng phía trên form dashboard.