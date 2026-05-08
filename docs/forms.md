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
| `ucSettings_Manager.cs`  | Admin / Manager | Cài đặt hệ thống & chat nội bộ.                                 |


---

## 2. Vai trò **Admin** (toàn quyền)


| Menu              | UserControl            | Chức năng                                           |
| ----------------- | ---------------------- | --------------------------------------------------- |
| Tổng quan         | `ucDashboard_Admin`    | Doanh thu toàn quán, biểu đồ cột/đường, KPIs.       |
| Quản trị viên     | `ucAdmin_Managers`     | Quản lý danh sách Manager (thêm, khóa, phân quyền). |
| Quản lý Nhân viên | `ucStaff_Manager`      | Danh sách toàn bộ NV, thêm/sửa/khóa tài khoản.      |
| Tiền lương        | `ucPayroll_Admin`      | Bảng lương tự tính theo công + thưởng.              |
| Feedback          | `ucFeedback_Admin`     | Tổng hợp feedback khách hàng, gắn cờ feedback xấu.  |
| Thông báo         | `ucNotification_Admin` | Danh sách notification từ hệ thống.                 |
| Gửi thông báo     | `ucBroadcastCenter`    | Soạn & gửi broadcast nội bộ.                        |
| Điểm danh         | `ucWorkTracking`       | Chấm công NV.                                       |
| Chat nội bộ       | `ucInternalChat`       | Chat với toàn bộ nhân viên.                         |
| Profile           | `ucProfile`            | Thông tin cá nhân.                                  |
| Cài đặt           | `ucSettings_Manager`   | Cấu hình hệ thống.                                  |


---

## 3. Vai trò **Manager** (quản lý ca)


| Menu                | UserControl              | Chức năng                                                      |
| ------------------- | ------------------------ | -------------------------------------------------------------- |
| Tổng quan           | `ucOverview_Manager`     | Tổng quan ca làm: doanh thu, đơn hàng, NV trực.                |
| Sản phẩm & Thực đơn | `ucProducts_Manager`     | Quản lý món; **Quản lý kho** mở `WarehouseManagerForm` (phiếu nhập tay / điền từ Excel·CSV → `AddInventoryImport`). UC trong `Warehouse/` có thể gắn thêm vào luồng Manager nếu cần. |
| Đơn hàng & Hóa đơn  | `ucOrders_Manager`       | Lịch sử order + chi tiết hóa đơn.                              |
| Quản lý Nhân viên   | `ucStaff_Manager`        | Danh sách NV thuộc ca quản lý.                                 |
| Thất thoát          | `ucLoss_Manager`         | Theo dõi nguyên liệu hao hụt, biểu đồ xu hướng.                |
| Feedback            | `ucFeedback_Manager`     | Đọc & phản hồi feedback của khách.                             |
| Thông báo           | `ucNotification_Manager` | Xử lý thông báo (SOS, cảnh báo NL).                            |
| Gửi thông báo       | `ucBroadcastCenter`      | Phát thông báo cho ca làm.                                     |
| Xin nghỉ            | `ucLeaveRequest`         | Duyệt đơn xin nghỉ NV.                                         |
| Điểm danh           | `ucWorkTracking`         | Chấm công.                                                     |
| Chat nội bộ         | `ucInternalChat`         | Chat.                                                          |
| Profile             | `ucProfile`              | Thông tin cá nhân.                                             |


---

## 4. Vai trò **Order Staff** (NV order tại quầy)


| Menu              | UserControl                   | Chức năng                                     |
| ----------------- | ----------------------------- | --------------------------------------------- |
| Tổng quan         | `ucOverview_Staff`            | Tổng quan ca cá nhân: số order, hoa hồng.     |
| Lên đơn / POS     | `ucPOS_OrderStaff`            | Màn hình POS - chọn món, in bill, thanh toán. |
| Khách hàng (CRM)  | `ucCRM_OrderStaff`            | Quản lý khách thân thiết, tích điểm.          |
| Tiền mặt          | `ucCashManagement_OrderStaff` | Két tiền mặt: nhập đầu ca/ca cuối, đối soát.  |
| Lịch sử chấm công | `ucAttendanceHistory`         | Xem giờ làm, ngày làm.                        |
| Xin nghỉ          | `ucLeaveRequest`              | Đăng ký nghỉ phép.                            |
| Chat nội bộ       | `ucInternalChat`              | Chat.                                         |
| Profile           | `ucProfile`                   | Thông tin cá nhân.                            |


---

## 5. Vai trò **Barista** (NV pha chế)


| Menu                 | UserControl           | Chức năng                                            |
| -------------------- | --------------------- | ---------------------------------------------------- |
| Tổng quan            | `ucOverview_Staff`    | Tổng quan ca.                                        |
| Màn hình Bếp (KDS)   | `ucKDS_Barista`       | Hiển thị order chờ pha realtime, tick xong từng món. |
| Cẩm nang Pha chế     | `ucRecipe_Barista`    | Công thức + định lượng từng món.                     |
| Báo động Nguyên liệu | `ucAlert_Barista`     | Cảnh báo NL sắp hết / hết hạn.                       |
| Lịch sử chấm công    | `ucAttendanceHistory` | Xem lịch sử.                                         |
| Xin nghỉ             | `ucLeaveRequest`      | Đăng ký nghỉ.                                        |
| Chat nội bộ          | `ucInternalChat`      | Chat.                                                |
| Profile              | `ucProfile`           | Thông tin cá nhân.                                   |


---

## 6. Module **Kho** (`GUI/Warehouse/`)

> Không còn menu đăng nhập riêng cho “thủ kho”. Các UserControl trong thư mục **`Warehouse/`** phục vụ màn **Sản phẩm & Thực đơn** của **Manager** (hoặc gắn thêm khi phát triển).

| UC                                | Ý nghĩa nghiệp vụ                                                       |
| --------------------------------- | ----------------------------------------------------------------------- |
| `ucStockControl_Warehouse`        | Tồn kho realtime, thao tác nhập chỉnh (nếu được gọi trong luồng Manager). |
| `ucSmartRestock_Warehouse`        | Gợi ý NL cần đặt thêm (buffer / tiêu thụ — theo shell UI).               |
| `ucEstimatedProduction_Warehouse` | Dự báo số ly pha được từ tồn + công thức.                                |

Chúng có thể được host trong form/tab khác của Manager — không có entry riêng trên sidebar cho role riêng.

---

## 7. Vai trò **Security** (Bảo vệ)


| Menu              | UserControl           | Chức năng                         |
| ----------------- | --------------------- | --------------------------------- |
| Tổng quan         | `ucOverview_Staff`    | Tổng quan ca.                     |
| Bãi xe            | `ucParking_Security`  | Quản lý xe vào/ra (biển số, vé).  |
| SOS An ninh       | `ucSOS_Security`      | Nút khẩn cấp + log sự cố an ninh. |
| Lịch sử chấm công | `ucAttendanceHistory` | Xem lịch sử.                      |
| Xin nghỉ          | `ucLeaveRequest`      | Đăng ký nghỉ.                     |
| Chat nội bộ       | `ucInternalChat`      | Chat.                             |
| Profile           | `ucProfile`           | Thông tin cá nhân.                |


---

## 8. Dialog (form bật ra khi cần)


| File                    | Mở từ                | Chức năng                                             |
| ----------------------- | -------------------- | ----------------------------------------------------- |
| `Login.cs`              | App khởi động        | Đăng nhập.                                            |
| `Register.cs`           | `Login`              | Đăng ký tài khoản mới (Manager duyệt).                |
| `ResetPassword.cs`      | `Login`              | Quên mật khẩu - gửi OTP qua email.                    |
| `FoodForm.cs`           | `ucProducts_Manager` | Thêm món mới.                                         |
| `FoodEditForm.cs`       | `ucProducts_Manager` | Sửa món.                                              |
| `FoodDetail.cs`         | `ucProducts_Manager` | Chi tiết món (hiển thị thành phần, giá).              |
| `EmployeeDetail.cs`     | `ucStaff_Manager`    | Chi tiết nhân viên.                                   |
| `WarehouseManagerForm.cs` | `ucProducts_Manager` (nút «Quản lý kho») | Hub: phiếu nhập tay hoặc mở `AddInventoryImport` sau khi đọc Excel/CSV. |
| `AddInventoryImport.cs` | `WarehouseManagerForm` | **Tạo phiếu nhập kho** (nhân viên, ngày, chi tiết NL + SL + đơn giá). |
| `BroadcastMessage.cs`   | `ucBroadcastCenter`  | Soạn 1 thông báo broadcast.                           |
| `ReportDialog.cs`       | Sidebar / SOS        | Báo cáo sự cố cho Manager.                            |


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