# HƯỚNG DẪN TEST UI/UX — QUẢN LÝ QUÁN CÀ PHÊ (NT106 - Nhóm 2)

> **Ghi chú quan trọng về dữ liệu:**
> - **[REAL]** = có nối backend thật (Firebase/SignalR qua BUS) — cần backend chạy + tài khoản hợp lệ.
> - **[MOCK]** = dữ liệu cứng / thao tác chỉ hiện hộp thoại (MsgBox), **không lưu** vào hệ thống.
> - Phần lớn màn là MOCK demo. Các nghiệp vụ REAL: Đăng nhập, Quên mật khẩu (email), Quản lý Nhân viên (thêm/sửa/xóa), Quản lý Món ăn (thêm/sửa/xóa), Nhập kho, Chat nội bộ.

---

## A. 5 VAI TRÒ (ROLE)

| Role (DB) | Hiển thị | Ghi chú |
|---|---|---|
| `admin` | Quản trị viên | Toàn quyền + đóng vai Quản lý |
| `manager` | Quản lý | Vận hành quán |
| `order staff` | Nhân viên Order | Bán hàng / POS |
| `barista` | Pha chế | Bếp / pha chế |
| `security` | Bảo vệ | Bãi xe / an ninh |

Sidebar (menu trái) trong `MainDashboard` được **dựng động theo role** của tài khoản đăng nhập (`GlobalSession.CurrentUser.Role`).

---

## B. BẢN ĐỒ TÍNH NĂNG

### B.1. Tính năng CHUNG (nhiều role)

| Tính năng | UserControl | Có ở role | Real/Mock |
|---|---|---|---|
| 💭 Chat nội bộ | `ucInternalChat` | **Tất cả 5** | [REAL] SignalR |
| 👤 Profile / Thông tin cá nhân | `ucProfile` | **Tất cả 5** | [MOCK] (lưu giả) |
| 🏖 Xin nghỉ / Nghỉ phép | `ucLeaveRequest` | Manager, Order, Barista, Security | [MOCK] |
| 📊 Tổng quan (Overview) | `ucDashboard_Admin` / `ucOverview_Manager` / `ucOverview_Staff` | Tất cả (UC khác nhau) | [MOCK] |
| ✅ Điểm danh / Lịch sử chấm công | `ucWorkTracking` (Admin, Manager) · `ucAttendanceHistory` (Order, Barista, Security) | Tất cả | [MOCK] (combo NV của AttendanceHistory là REAL) |
| 📢 Gửi thông báo | `ucBroadcastCenter` | Admin, Manager | [MOCK] |
| 🔔 Thông báo | `ucNotification_Admin` / `ucNotification_Manager` | Admin, Manager | [MOCK] |
| 💬 Feedback | `ucFeedback_Admin` / `ucFeedback_Manager` | Admin, Manager | [MOCK] |
| 📋 Audit log | `ucAuditLog` | Admin, Manager | [MOCK] |
| 👤 Nhân viên | `ucStaff_Manager` | Admin, Manager | [REAL] |

### B.2. Tính năng RIÊNG theo role

**ADMIN (Quản trị viên)**
| Menu | UC | Real/Mock |
|---|---|---|
| 📊 Tổng quan toàn quán | `ucDashboard_Admin` | [MOCK] biểu đồ |
| 👥 Quản trị viên (quản lý các Manager) | `ucManagers_Admin` | [MOCK] + đóng vai QL |
| 💰 Tiền lương | `ucPayroll_Admin` | [MOCK] |
| 💸 Tiền chi | `ucExpenses_Admin` | [MOCK] (in-memory) |
| 📊 Xuất báo cáo | `ucReport_Admin` | [MOCK] xuất file giả |

**MANAGER (Quản lý)**
| Menu | UC | Real/Mock |
|---|---|---|
| 🍽 Sản phẩm & Thực đơn | `ucProducts_Manager` | [REAL] menu + kho |
| 📋 Đơn hàng & Hóa đơn | `ucOrders_Manager` | [MOCK] |
| 📅 Lịch ca làm | `ucSchedule_Manager` | [MOCK] |
| 🎁 Khuyến mãi | `ucPromotion_Manager` | [MOCK] |
| 📉 Thất thoát | `ucLoss_Manager` | [MOCK] + báo cáo sự cố |

**ORDER STAFF (Nhân viên Order)**
| Menu | UC | Real/Mock |
|---|---|---|
| 🛒 Lên đơn / POS | `ucPOS_Order` | [REAL] menu, [MOCK] thanh toán |
| 👥 Khách hàng (CRM) | `ucCRM_Order` | [MOCK] |
| ⭐ Loyalty | `ucLoyalty_Order` | [MOCK] |
| 📆 Đặt bàn | `ucReservation_Order` | [MOCK] |
| 📱 Đặt tại bàn QR | `ucSelfOrder_Order` | [MOCK] (QR giả) |
| 💵 Tiền mặt | `ucCashManagement_Order` | [MOCK] |

**BARISTA (Pha chế)**
| Menu | UC | Real/Mock |
|---|---|---|
| 🍳 Màn hình Bếp (KDS) | `ucKDS_Barista` | [MOCK] |
| 📖 Cẩm nang Pha chế | `ucRecipe_Barista` | [MOCK] |
| ⚠ Báo động NL | `ucAlert_Barista` | [MOCK] |

**SECURITY (Bảo vệ)**
| Menu | UC | Real/Mock |
|---|---|---|
| 🅿 Bãi xe | `ucParking_Security` | [MOCK] |
| 🚨 SOS An ninh | `ucSOS_Security` | [MOCK] |

---

## C. HƯỚNG DẪN TEST CHI TIẾT (Ấn nút → Kết quả)

### C.0. Chuẩn bị
- Chạy **backend** trước (xem `backend/` — cần `serviceAccountKey.json` + `.env`) để các tính năng [REAL] hoạt động.
- Đăng nhập bằng tài khoản đúng từng role để kiểm tra sidebar tương ứng.
- Màn [MOCK]: dù không có backend vẫn test được UI (chỉ hiện MsgBox / đổi dữ liệu trên lưới tạm).

### C.1. Luồng xác thực (Auth) [REAL]

**Login** (`Chào mừng trở lại 👋`)
| Thao tác | Kết quả mong đợi |
|---|---|
| Nhập email + mật khẩu → **Đăng nhập** | Nút đổi "Đang xử lý...". Đúng → MsgBox Success "Xin chào {vai trò} {Tên}!" → mở **MainDashboard** theo role, ẩn Login. Sai → MsgBox Error "Đăng nhập thất bại". |
| Giữ nút **Hiện** (👁) | Giữ thì hiện mật khẩu (chữ "Ẩn"); thả thì ẩn lại. |
| Tick **Ghi nhớ đăng nhập** rồi đăng nhập | Lưu email + mật khẩu (mã hóa DPAPI) vào Settings; lần sau tự điền. |
| **Quên mật khẩu?** | Ẩn Login → mở form **ConfirmEmail**. |
| **✕** | Thoát ứng dụng. |

**ConfirmEmail → VerifyCode → ResetPassword** (luồng quên mật khẩu)
| Thao tác | Kết quả |
|---|---|
| ConfirmEmail: nhập email → **Gửi mã xác nhận** | Đúng → MsgBox "Thành công" → mở **VerifyCode** (đếm ngược 60s). Sai → MsgBox "Lỗi". |
| VerifyCode: bỏ trống → **Xác nhận** | MsgBox Warning "Vui lòng nhập mã xác nhận!". |
| VerifyCode: mã ≠ 8 ký tự chữ+số → **Xác nhận** | MsgBox Warning "Mã xác nhận không hợp lệ!...". |
| VerifyCode: quá 60s → **Xác nhận** | MsgBox Warning "Mã ... đã hết hạn (60s)...". |
| VerifyCode: mã sai → **Xác nhận** | MsgBox Error "Mã xác nhận không đúng...". |
| VerifyCode: mã đúng → **Xác nhận** | Mở form **ResetPassword**. |
| VerifyCode: **Gửi lại mã** | Gửi mã mới + reset 60s; MsgBox Success. |
| ResetPassword: nhập 2 mật khẩu → **Lưu mật khẩu mới** | Đúng → MsgBox Success "Cập nhật mật khẩu thành công!" → về **Login**. Sai (rỗng/không khớp/yếu) → MsgBox Error (validate ở BUS). |

> ⚠️ Lỗi nhỏ phát hiện: link "← Quay lại đăng nhập" ở **ResetPassword** thực ra mở lại **VerifyCode** (không phải Login) — sai so với nhãn.

### C.2. Khung Dashboard (`MainDashboard`)
| Thao tác | Kết quả |
|---|---|
| Bấm **mục menu sidebar** (vd "📊 Tổng quan", "🛒 Lên đơn/POS") | Nạp UserControl tương ứng vào vùng nội dung (Dock=Fill), tô sáng nút đang chọn, đổi tiêu đề. Mục menu thay đổi theo role. |
| **🚪 Đăng xuất** | Mở lại Login, gọi `GlobalSession.Logout()`, đóng các form khác. **Không có xác nhận**. |
| **—** (thu nhỏ) / **✕** (đóng) | Thu nhỏ cửa sổ / Thoát app (không xác nhận). |
| Kéo vùng header | Di chuyển cửa sổ không viền. |

### C.3. Màn ADMIN

**ucDashboard_Admin — Tổng quan toàn quán** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **Thu / Chi / Thất thoát** (3 tab) | Đổi bảng chi tiết theo nhóm + cập nhật phụ đề. |
| **Ngày / Tháng / Năm** (biểu đồ doanh thu) | Vẽ lại biểu đồ cột theo mốc thời gian. |
| **Tháng / Quý / Năm** (biểu đồ feedback) | Vẽ lại biểu đồ tốt/xấu + cập nhật nhãn %. |
| **Xuất Excel / In / Nhập Excel** | Mở Save/Print/Open dialog → MsgBox "...đang được phát triển" (chưa xuất file thật). |
| ComboBox khoảng thời gian | Chỉ đổi phụ đề, **không** lọc lại dữ liệu. |

**ucManagers_Admin — Quản lý các Manager** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **⚡ Đóng vai Quản lý** | MsgBox Yes/No → Yes: đổi role tạm = manager, **mở MainDashboard mới** (giao diện Manager), đóng dashboard cũ. |
| **+ Thêm Quản lý** | Mở form **AddEmployee** → OK: MsgBox "Đã thêm Quản lý mới!" + reload. |
| **Sửa** | Chưa chọn dòng → return. Có chọn → MsgBox Info "Mở form chỉnh sửa... {tên}" (chỉ báo, mock). |
| **Duyệt (N)** | Bảng rỗng → Warning. Có đơn → Yes/No → Yes: bảng thành "✓ đã duyệt", nút thành "Duyệt (0)". |
| Click tiêu đề **📇 Hồ sơ Quản lý** | Mở dialog **ManagerProfileDetail**. |
| Click tiêu đề **🏖 Đơn xin nghỉ** | Mở dialog **LeaveRequestDetail** (3 đơn mock). |
| Click tiêu đề **🔔 Lịch sử thao tác** | Mở dialog **AuditLogDetail** (5 dòng mock). |

**ucPayroll_Admin — Tiền lương** [MOCK]
| Thao tác | Kết quả |
|---|---|
| ComboBox **Tháng** | Reload lại 7 dòng lương mock (không đổi theo tháng thật). |
| **⚡ Tính lương tự động** | MsgBox Success liệt kê quy tắc tính lương + reload bảng. |
| Chọn dòng có lý do trừ lương | Tiêu đề đổi đỏ "Bảng lương — {tên} (Trừ: {lý do})". |

**ucExpenses_Admin — Tiền chi** [MOCK in-memory]
| Thao tác | Kết quả |
|---|---|
| **+ Thêm khoản chi** | Mở **InputDialog** "Thêm khoản chi". Nhập mô tả → thêm 1 dòng vào lưới (Số tiền=0) + MsgBox Success. Bỏ trống → không thêm. |
| **📥 Xuất Excel** | MsgBox Success "Đã xuất file Excel..." (không xuất thật). |

**ucReport_Admin — Xuất báo cáo** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **Doanh thu / Bảng lương / Kho hàng / Feedback** | Đổi bảng xem trước theo loại báo cáo. |
| **📥 Xuất Excel / 📄 Xuất PDF** | MsgBox Success "Đã xuất file..." (giả). |
| **📧 Gửi email** | Yes/No → Yes: MsgBox "Đã gửi email báo cáo thành công!" (giả). |

**ucFeedback_Admin — Phản hồi khách hàng** [MOCK]
| Thao tác | Kết quả |
|---|---|
| ComboBox **Trạng thái** | Lọc lưới theo trạng thái. |
| Chọn dòng feedback | Đổ chi tiết sang panel phải. |
| **💬 Trả lời** | Mở dialog **ReplyFeedback** → OK: trạng thái dòng = "Đã trả lời" + MsgBox Success. |
| **✓ Đã xử lý** | Đổi trạng thái dòng = "Đã xử lý" + MsgBox Success. |
| **🗑 Xóa** | Yes/No → Yes: MsgBox "Đã xóa..." (**lưu ý: dòng KHÔNG thực sự bị xóa** — mock). |

**ucNotification_Admin — Thông báo** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Chọn dòng thông báo | Đổ chi tiết + hiện/ẩn nút theo loại (Xin nghỉ → Duyệt/Từ chối/Chat; Feedback xấu chưa xử lý → "Chat QL ngay!" đỏ). |
| **Double-click** dòng | Đánh dấu đã đọc + MsgBox điều hướng (mock). |
| **✓ Duyệt / ✕ Từ chối** (đơn Xin nghỉ) | Chèn [ĐÃ DUYỆT]/[TỪ CHỐI] vào nội dung + MsgBox. |
| **✓ Đọc tất cả** | Tất cả thành đã đọc, "Đã đọc hết". |
| **💬 Chat với quản lý / → Đi tới trang** | MsgBox Info (mock, không điều hướng thật). |

### C.4. Màn MANAGER

**ucOverview_Manager — Tổng quan** [MOCK] — chỉ hiển thị thẻ + bảng tin, **không có tương tác thật** (các label/listbox handler rỗng).

**ucProducts_Manager — Sản phẩm & Thực đơn** [REAL menu]
| Thao tác | Kết quả |
|---|---|
| (onLoad) | Lưới menu nạp từ **FoodBUS.GetListFoods()** (REAL). |
| **+ Thêm** | Mở dialog **AddFood** → OK: reload + MsgBox "Món ăn mới đã được thêm...". |
| **✏ Sửa** | Chưa chọn → Warning. Có chọn → mở **EditFood** → OK: reload. |
| **✖ Xóa** | Chưa chọn → Warning. Có chọn → Yes/No → Yes: **FoodBUS.DeleteFood** (REAL) → MsgBox kết quả. |
| **Double-click** dòng | Mở dialog **FoodDetail** (xem + có thể xóa). |
| Gõ **🔍 Tên/loại**, **Giá từ**, **Đến** | Lọc lưới tức thời (RowFilter). |
| **✖** (xóa lọc) | Xóa hết bộ lọc. |
| **Quản lý kho** | Mở dialog **WarehouseManager**. |
| **📊 Xem Biểu Đồ** | **Không có handler** — không làm gì (mock). |

**ucOrders_Manager — Đơn hàng & Hóa đơn** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **🔍 Lọc** (theo combo trạng thái) | Lọc lưới bàn theo trạng thái. |
| Double-click dòng **Cảnh báo món chờ quá lâu** | Xóa dòng đó khỏi danh sách (coi như đã xong). |
| **Cập nhật** (2 nút) | **Không có handler** (mock). |

**ucStaff_Manager — Nhân viên** [REAL]
| Thao tác | Kết quả |
|---|---|
| (onLoad) | Nạp NV thật từ **EmployeeBUS.GetAllEmployeesAsync()** (lọc bỏ admin). |
| **+ Thêm NV Mới** | Mở **AddEmployee** → OK: reload + MsgBox. |
| **✏ Sửa** | Chưa chọn → Warning. Có chọn → mở **EditEmployee** → OK: reload. |
| **Double-click** dòng NV | Mở dialog **EmployeeDetail** (xem + có thể xóa). |
| Gõ **🔍 Tên/Mã**, combo **Vị trí**, **Trạng thái** | Lọc lưới tức thời. |
| **✔ Duyệt** (đơn nghỉ) | Chưa chọn → Warning. Có chọn → MsgBox Success + xóa dòng đã duyệt. |
| **🔍 Lọc** | **Không có handler** (lọc đã tự chạy qua gõ/chọn). |

**ucSchedule_Manager — Lịch ca làm** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **◀ Tuần trước / Tuần sau ▶** | Vẽ lại lưới ca của tuần tương ứng. |
| **📢 Đăng lịch** | MsgBox Success "Đã đăng lịch ca tuần này...". |
| Click ô **⚠ Thiếu** | MsgBox Warning "Ca này chưa đủ người!...". |
| Click ô có tên NV | MsgBox Info "Nhân viên: {...}" (gợi ý double-click để sửa — chưa wired). |

**ucPromotion_Manager — Khuyến mãi** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **⏰ Happy Hour / 🎯 Combo / 🏷 Voucher** | Chuyển tab (ẩn/hiện panel + lưới tương ứng). |
| **+ Thêm khung giờ / Sửa khung giờ / + Thêm combo** | MsgBox "đang phát triển" / "thành công" (mock, không thêm dòng). |
| Nhập mã + % → **Tạo voucher** | Rỗng mã → Warning. Có mã → MsgBox Success "Đã tạo voucher..." (mock). |

**ucLoss_Manager — Thất thoát** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **Ngày / Tháng / Năm** | Đổi tổng thất thoát + lưới + biểu đồ. |
| **⚠ Báo cáo sự cố** | Mở dialog **ReportIncident** → OK/Yes: MsgBox "Đã gửi báo cáo!". |

**ucNotification_Manager — Thông báo** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Chọn dòng đơn nghỉ → **✓ Duyệt / ✕ Từ chối** | Đổi trạng thái dòng (xanh/đỏ) + MsgBox. |
| **💬 Chat** | MsgBox "Mở chat với {tên}..." (mock). |
| **💾 Lưu lịch** | MsgBox "Đã lưu lịch làm việc thành công!" (mock). |

### C.5. Màn ORDER (Nhân viên Order)

**ucPOS_Order — Lên đơn / POS** [REAL menu, MOCK thanh toán]
| Thao tác | Kết quả |
|---|---|
| (onLoad) | Nạp menu từ **FoodBUS.GetListFoods()**; rỗng/lỗi → 12 món mock. |
| Click **thẻ món** | Thêm món vào đơn (đã có thì +1), cập nhật Tổng cộng. |
| Gõ **Giảm giá** | Tổng cộng = max(0, tạm tính − giảm). |
| **💳 Thanh toán** | Đơn trống → Warning. Có món → mở **PaymentDialog** (Tiền mặt/Thẻ/VietQR) → xác nhận → mở **form Hóa đơn** (có QR feedback) → đóng đơn. |
| **🗑 Hủy đơn** | Mở **InputDialog** nhập lý do (bắt buộc) → xóa đơn + MsgBox. |
| Tab **🪑 Sơ đồ bàn** | Dựng 15 bàn; click bàn → chọn bàn. 4 nút **Gộp/Tách/Chuyển/Tách HĐ** (mỗi nút InputDialog → MsgBox). |
| Tab **📜 Lịch sử** | Lưới 5 hóa đơn mock. |
| **📊 Báo cáo** | Yes/No → Yes: MsgBox "Đã gửi báo cáo cho quản lý!". |

**ucCRM_Order — Khách hàng** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **🔍 Tìm** | Lọc lưới theo tên/SĐT. |
| **+ Thêm** | Xóa trắng panel chi tiết (không mở dialog). |
| **💾 Lưu khách hàng** | Thiếu tên/SĐT → Warning. Đủ → MsgBox Success (mock, không thêm dòng). |
| **📊 Báo cáo** | Yes/No → Success. |

**ucLoyalty_Order — Loyalty** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Nhập SĐT → **🔍 Tìm khách** | < 9 số → Warning. Hợp lệ → hiện panel khách + hạng + lịch sử điểm (mock). |
| **+ Đăng ký mới** | InputDialog họ tên → MsgBox đăng ký (mock). |
| **+ Tích điểm đơn này** | InputDialog số tiền → tính điểm = tiền/3000 → MsgBox. |
| **🎁 Đổi quà** | MsgBox danh sách quà "đang hoàn thiện". |

**ucReservation_Order — Đặt bàn** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Gõ **🔍 tìm** / combo **trạng thái** | Lọc lưới + cập nhật "N lượt đặt". |
| **+ Đặt bàn mới** | InputDialog họ tên → thêm dòng RES-### + MsgBox Success. |
| **📧 Nhắc hôm nay** | MsgBox "Đã gửi email nhắc đến 3 khách..." (giả). |
| **Double-click** dòng | MsgBox Info chi tiết đặt bàn. |

**ucSelfOrder_Order — Đặt tại bàn QR** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Combo **bàn** | Vẽ lại QR giả + đổi nhãn bàn. |
| **🖨 In QR** | MsgBox Success "Đã in QR cho {bàn}!". |
| **▶ Nhận đơn mới (test)** | Chèn đơn "Mới!" lên đầu lưới + MsgBox "Đơn vào realtime" (giả SignalR). |

**ucCashManagement_Order — Tiền mặt** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **▶ Bắt đầu ca** | Đã mở ca → Warning. Chưa → disable nút + MsgBox Success. |
| **■ Kết thúc ca** | Chưa mở ca → Warning. Có → Yes/No → Yes: MsgBox tổng kết ca. |
| **📊 Báo cáo** | Yes/No → Success. |

### C.6. Màn BARISTA (Pha chế)

**ucKDS_Barista — Màn hình Bếp** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Nút trên thẻ đơn (**Bắt đầu pha / Hoàn thành / ✓**) | MsgBox "Đã cập nhật trạng thái đơn #...!" (**mock — thẻ KHÔNG chuyển cột**). |
| **📊 Báo cáo** | Yes/No → Success. |

**ucRecipe_Barista — Cẩm nang Pha chế** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Chọn món trong **danh sách trái** | Hiện nguyên liệu + các bước bên phải. |
| **📊 Báo cáo** | Yes/No → Success. |
| Ô **🔍 Tìm công thức** | **Không có handler lọc** (mock). |

**ucAlert_Barista — Báo động NL** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Chọn loại + nhập nội dung → **🚨 Gửi cảnh báo** | Rỗng → Warning. Có → MsgBox Success + chèn dòng "Chờ xử lý" lên đầu lưới + xóa ô nhập. |
| **📊 Báo cáo** | Yes/No → Success. |

### C.7. Màn SECURITY (Bảo vệ)

**ucParking_Security — Bãi xe** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Nhập biển số + chọn loại → **Xe vào** | Trống biển số → Warning; bãi đầy → Error. Hợp lệ → chèn dòng "Đang gửi", giảm chỗ trống, MsgBox Success. |
| Chọn dòng → **Xe ra** | Chưa chọn → Warning; đã ra rồi → Warning. Hợp lệ → set "Đã ra", tăng chỗ trống, MsgBox Success. |
| **📊 Báo cáo** | Yes/No → Success. |

**ucSOS_Security — SOS An ninh** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **SOS** (nút đỏ to) | Yes/No "XÁC NHẬN SOS" → Yes: chèn dòng sự cố "Đang xử lý" + MsgBox "ĐÃ GỬI TÍN HIỆU KHẨN CẤP!". |
| **📊 Báo cáo** | Yes/No → Success. |

### C.8. Màn DÙNG CHUNG

**ucProfile — Thông tin cá nhân** [MOCK lưu]
| Thao tác | Kết quả |
|---|---|
| **Lưu thay đổi** | MsgBox Success (mock, không lưu thật). |
| **Đổi mật khẩu** | Validate rỗng / < 6 ký tự / không khớp → Warning. Đúng → Success + xóa ô (mock, không đổi thật). |
| **Đổi ảnh đại diện** | OpenFileDialog ảnh → load vào PictureBox + Success (in-memory). |
| Mã NV / Email | Read-only. |

**ucLeaveRequest — Xin nghỉ** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Chọn ngày + lý do → **Gửi yêu cầu** | Lý do rỗng → Warning; Đến < Từ → Warning. Đúng → chèn dòng "Chờ duyệt" + MsgBox Success. |
| **📊 Báo cáo** | Yes/No → Success. |
| **Quản lý nghỉ** (chỉ admin/manager) | Mở **popup Form** chứa `ucAttendanceHistory` (1000×650). |

**ucInternalChat — Chat nội bộ** [REAL SignalR]
| Thao tác | Kết quả |
|---|---|
| (onLoad) | Nạp danh sách NV thật (EmployeeBUS) + kết nối SignalR (ChatManager). |
| Nhập tin → **Gửi ➤** (hoặc Enter) | Rỗng → Warning. Có → gửi qua ChatManager (REAL) + xóa ô. |
| Combo **người nhận** | Chuyển phòng chat (nhóm / 1 người). |
| **📢 Thông báo toàn bộ** (admin/manager) | Yes/No → Yes: chèn dòng [THÔNG BÁO] vào danh sách (local) + Success. |
| **↗ Mở rộng** | MsgBox "Đang mở Messenger..." (mock). |

**ucWorkTracking / ucAttendanceHistory — Chấm công** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Đổi **Tháng** (picker) | Reload lại dữ liệu mock (không lọc thật). |
| **📊 Báo cáo** / **⚠ Báo cáo sai sót** | Yes/No → Success. |
| AttendanceHistory: combo NV + **🔍 Lọc** (admin/manager) | Combo NV nạp thật (InventoryImportBUS.GetEmployees); lưới hiện rỗng (chưa nối dữ liệu chấm công). |

**ucBroadcastCenter — Gửi thông báo** [MOCK]
| Thao tác | Kết quả |
|---|---|
| **+ Soạn thông báo mới** | Mở dialog **SendBroadcast** → OK: MsgBox "Đã gửi thông báo!" + reload lịch sử. |
| **Làm mới** | Reload lưới lịch sử. |
| Gõ **🔍 tìm** | Lọc lưới theo tiêu đề/người nhận. |

**ucAuditLog — Nhật ký kiểm toán** [MOCK]
| Thao tác | Kết quả |
|---|---|
| Gõ **🔍 tìm** / combo **Loại thao tác** / **Nhân viên** | Lọc lưới + cập nhật "N bản ghi". |
| **Xóa lọc** | Reset bộ lọc. |
| **Double-click** dòng | MsgBox Info "Chi tiết nhật ký". |

### C.9. DIALOGS (Form popup)

| Dialog | Mở từ | Nút chính → Kết quả |
|---|---|---|
| **AddEmployee** [REAL] | "Thêm NV/Quản lý" | **Lưu** → EmployeeBUS.AddEmployeeAsync → Success/Error. **Hủy** → đóng. |
| **EditEmployee** [REAL] | "Sửa NV" | **Lưu thay đổi** → Update (active) / Lock (inactive) → Success/Error. |
| **EmployeeDetail** [REAL] | Double-click NV | **Xóa** → Yes/No → DeleteEmployeeAsync. **Đóng**. |
| **AddFood** [REAL] | "Thêm món" | **Thêm** → FoodBUS.AddFood → Success/Error. |
| **EditFood** [REAL] | "Sửa món" | **Cập nhật** → FoodBUS.UpdateFood → Success/Error. |
| **FoodDetail** [REAL] | Double-click món | **Xóa món** → Yes/No → FoodBUS.DeleteFood. **Đóng**. |
| **WarehouseManager** [REAL] | "Quản lý kho" | **Tạo phiếu (nhập tay)** → mở AddInventoryImport. **Điền từ Excel/CSV** → đọc file → AddInventoryImport(prefill). |
| **AddInventoryImport** [REAL] | WarehouseManager | Chọn NV + dòng nguyên liệu → **Tạo phiếu nhập** → InventoryImportBUS.AddImport → Success. Lưới tự tính tổng. |
| **PaymentDialog** [MOCK] | POS "Thanh toán" | Chọn Tiền mặt/Thẻ/VietQR, nhập tiền khách → **✓ Xác nhận** (thiếu tiền → Error). Trả về phương thức TT. |
| **ReplyFeedback** [trả về] | "Trả lời" feedback | **Gửi trả lời** (rỗng → Warning) → trả ReplyText. |
| **ReportIncident** [trả về] | "Báo cáo sự cố" | **Gửi báo cáo** (OK) / **Gửi + Chat Manager** (Yes) / **Hủy**. |
| **SendBroadcast** [trả về] | "Soạn thông báo" | Chọn Tất cả/Riêng + mức độ + nội dung → **Gửi thông báo** (OK). |
| **ManagerProfileDetail** [MOCK] | tiêu đề Hồ sơ QL | Lưới 3 QL read-only. **Đóng**. |
| **LeaveRequestDetail** [MOCK] | tiêu đề Đơn nghỉ | Thẻ đơn; **✔ Duyệt** (đổi UI local). **Đóng**. |
| **AuditLogDetail** [MOCK] | tiêu đề Lịch sử | Lưới audit read-only. **Đóng**. |
| **InputDialog** [tiện ích] | nhiều nơi | Nhập 1 dòng → **Xác nhận**/Enter (trả text) hoặc **Hủy**/Esc (null). |

---

## D. CHECKLIST TEST NHANH

- [ ] Đăng nhập đúng/sai từng role → sidebar đúng vai trò.
- [ ] Luồng quên mật khẩu: ConfirmEmail → VerifyCode (validate mã) → ResetPassword.
- [ ] **[REAL]** CRUD Nhân viên (Admin/Manager): Thêm/Sửa/Xóa/Chi tiết.
- [ ] **[REAL]** CRUD Món ăn (Manager): Thêm/Sửa/Xóa/Chi tiết + lọc + nhập kho (tay & Excel/CSV).
- [ ] **[REAL]** Chat nội bộ: gửi tin nhóm + 1 người + (admin/manager) thông báo toàn bộ.
- [ ] POS: gọi món → thanh toán (3 phương thức) → hóa đơn; hủy đơn; sơ đồ bàn; tách HĐ.
- [ ] Mỗi màn [MOCK]: kiểm tra nút mở đúng dialog / MsgBox đúng nội dung + validate rỗng.
- [ ] Đổi vai trò (Admin → ⚡ Đóng vai Quản lý) → giao diện Manager.

> 🐞 **Lỗi đã biết:** (1) ResetPassword link "Quay lại đăng nhập" mở nhầm VerifyCode. (2) Nhiều nút là demo (KDS không chuyển cột, Xóa feedback không xóa dòng, Báo cáo/Xuất file chỉ hiện MsgBox).
