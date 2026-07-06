# Checklist kiểm thử giao diện — NT106 Quản Lý Quán Cafe

Tài liệu này gồm 3 phần:
1. **Cách chạy unit test tự động** (157 test: 106 xUnit client + 51 Jest backend).
2. **Regression** — kiểm lại 12 lỗi vừa được sửa (làm trước, nhanh).
3. **Checklist đầy đủ theo màn hình** — từng nút + thanh tìm kiếm/lọc.

Quy ước: ✅ = kết quả mong đợi khi PASS. Mọi thao tác "lưu/duyệt/thêm" cần **server (backend) đang chạy**; nếu offline thì bảng để trống và **không được crash**.

---

## 1. Unit test tự động

```bash
# Client (xUnit) — 106 test
cd client/Tests/Logic.Tests
dotnet test

# Backend (Jest) — 51 test
cd backend
npm test
```

Client phủ 4 khối logic thuần (không cần server, không cần đóng app đang chạy):
- `AppMath` — parse tiền, số lượng nhập kho, tổng đơn, tiền thối, tổng lương, điểm tích luỹ.
- `Validation` — email, mật khẩu mạnh, OTP 8 số, SĐT VN, ngày vào làm, guard trường rỗng.
- `SearchFilter.AllColumnsFilter` — **lõi của mọi thanh tìm kiếm** (kể cả escape `%`, `[`, `'`).
- `EmployeeText` — mapping vai trò/trạng thái mà các bộ lọc nhân sự phụ thuộc.

Backend (Firebase được mock) phủ: auth controller (login/OTP), employees, foods,
**generic CRUD 23 endpoint** (`resources.controller`), chat, auth middleware,
và `otp.service` (hash+pepper, hết hạn, chặn brute-force, token dùng 1 lần).

Mong đợi: `Passed! Failed: 0`.

---

## 2. Regression — 12 lỗi vừa sửa

| # | Màn hình | Thao tác kiểm tra | ✅ Kết quả đúng |
|---|----------|-------------------|----------------|
| 1 | **Đăng nhập → Quên mật khẩu** | Bấm "Quên mật khẩu" → nhập email → gửi mã → (huỷ giữa chừng hoặc đi hết tới đổi mật khẩu) → quay lại Login | Form Login hiện lại và **bấm/gõ được bình thường** (trước đây bị đơ/không click được) |
| 2 | **Order → Đặt tại bàn QR** | Xem nhãn dưới bảng "đơn đến" | Đếm **chỉ đơn QR của hôm nay**, con số khớp số dòng trong bảng |
| 3 | **Admin → Tiền lương** | Sửa 1 dòng, đặt "Trừ lương" = `200000` (dương) → Lưu | Tổng lương **GIẢM** đúng 200.000 (trước đây bị cộng thành tăng) |
| 4 | **Manager → Thất thoát** | Ghi nhận 1 khoản mới → xem biểu đồ | Cột biểu đồ **thay đổi theo dữ liệu thật** (không còn là số cứng) |
| 5 | **Dialog Nhập kho** | Nhập số lượng `1.5` một dòng → xem "Thành tiền" | Số lượng hiểu là **2** (làm tròn), **không** thành 15 |
| 6 | **Manager → Đơn hàng** | Mở combo lọc trạng thái | Chỉ còn `Tất cả / Đang phục vụ / Chờ lên món` (bỏ "Chờ thanh toán" vốn luôn rỗng) |
| 7 | **Admin → Tiền chi** | Chọn tháng khác tháng hiện tại → Xuất Excel | Tên file & tiêu đề theo **đúng tháng đang chọn** |
| 7b | **Admin → Xuất báo cáo** | Chọn tháng khác → Xuất Excel/PDF | Tên file theo **đúng tháng đang chọn** |
| 8 | **Manager → Lịch ca làm** | Tuần đã đủ người mọi ca | Banner cảnh báo vàng **ẩn hẳn** (trước đây luôn hiện) |
| 9 | **Chấm công (nhân viên thường)** | Đổi "Từ ngày"/"Đến ngày" | Bảng **tự lọc lại ngay** (không cần nút Lọc vốn bị ẩn) |
| 10 | **Xin nghỉ** | Chọn Từ = Đến = cùng 1 ngày → Gửi | Không báo lỗi "ngày kết thúc phải sau…"; gửi được (nghỉ 1 ngày) |
| 11 | **Dialog Thêm nhân viên** | Không chọn vị trí → Lưu | Cảnh báo "Vui lòng chọn vị trí…"; khi server trả lỗi thì **có thông báo lỗi** (trước đây im lặng) |
| 12 | **Manager → Khuyến mãi → Voucher** | Tạo voucher để trống ô "% giảm" → tạo | Thông báo hiển thị mức giảm **đúng bằng giá trị đã lưu** (10%), không phải "Giảm %" |

---

## 3. Checklist đầy đủ theo màn hình

Với mỗi thanh tìm kiếm: gõ 1 từ khoá khớp một phần → danh sách lọc lại; xoá từ khoá → hiện đủ; gõ ký tự lạ (`%`, `'`, `[`) → **không crash**. Với mỗi nút: bấm khi **chưa chọn dòng** → phải báo "Vui lòng chọn…" chứ không crash.

### Đăng nhập / Auth
- [ ] Đăng nhập đúng → vào đúng dashboard theo vai trò; sai → báo lỗi, nút bật lại.
- [ ] "Nhớ mật khẩu" tích → lần sau tự điền; bỏ tích → không lưu.
- [ ] Hiện/ẩn mật khẩu (giữ chuột).
- [ ] Quên mật khẩu → gửi mã → nhập mã → đổi mật khẩu → về Login (xem Regression #1).
- [ ] "Quay lại đăng nhập" ở mỗi bước → về Login, **click được**.

### Admin
**Tổng quan (Dashboard):** thẻ Doanh thu/Lợi nhuận/Chi phí/Thất thoát hiển thị số; "Chi tiết →" mở biểu đồ 12 tháng; double-click dòng bảng → chi tiết.
- [ ] Lợi nhuận = Doanh thu − Chi phí − Thất thoát (kiểm nhẩm với các thẻ).

**Danh sách Quản lý:** tìm kiếm (mọi cột), Thêm/Sửa QL, duyệt đơn nghỉ của QL, double-click xem chi tiết, "Đóng vai Quản lý".
- [ ] Nút "Duyệt (n)" hiển thị đúng số đơn chờ.

**Nhân viên:** tìm kiếm; lọc Vị trí + Trạng thái; Thêm/Sửa/Xem; duyệt đơn nghỉ.
- [ ] Lọc "Nhân viên Order" ra đúng người (mapping vai trò — đã có unit test).

**Tiền lương:** chọn tháng; "Tính lương lại"; Sửa dòng; double-click chi tiết (xem Regression #3).

**Tiền chi:** chọn tháng; Thêm khoản chi; Sửa; **Xuất Excel** (Regression #7); double-click chi tiết.

**Xuất báo cáo:** đổi loại (Doanh thu/Lương/Kho/Feedback) → bảng đổi cột; chọn tháng; **Xuất Excel/PDF** (Regression #7b).

**Feedback:** lọc trạng thái; Trả lời; Đánh dấu đã xử lý; Sửa; Xoá.

**Thông báo:** double-click đánh dấu đã đọc; "Đọc tất cả"; nút Chấp nhận/Từ chối/Chat hiện đúng theo loại.

### Manager
**Tổng quan ca làm:** thẻ doanh thu ngày/tháng; feed thông báo; "Làm mới".

**Sản phẩm & Thực đơn:** tìm kiếm + lọc giá (từ–đến); Thêm/Sửa/Xoá món; Nhập kho (mở Dialog); double-click chi tiết.
- [ ] Lọc giá "từ 30000 đến 50000" ra đúng khoảng.

**Đơn hàng & Hóa đơn:** lọc trạng thái bàn (Regression #6); Sửa bàn; double-click bàn; double-click cảnh báo bếp → xoá khỏi danh sách.

**Nhân viên / Lịch ca / Khuyến mãi / Thất thoát / Feedback / Thông báo:** như phần Admin/dưới.

**Lịch ca làm:** ‹ › đổi tuần; "Đăng lịch"; click ô ca; banner cảnh báo (Regression #8).

**Khuyến mãi:** 3 tab Happy Hour/Combo/Voucher; Thêm mỗi loại; Sửa Happy Hour; tạo Voucher (Regression #12).

**Thất thoát:** nút Ngày/Tháng/Năm đổi mốc → bảng + **biểu đồ đổi theo dữ liệu thật** (Regression #4); Ghi nhận; Sửa.

**Xử lý Thông báo:** Duyệt/Từ chối đơn nghỉ (lưu thật); lưu lịch tuần; Chat.

### Order Staff
**POS:** tab Lên đơn/Sơ đồ bàn/Lịch sử; thêm món (nút +/click thẻ) → lưới cập nhật + huy hiệu SL; nhập **giảm giá** → tổng cập nhật (Regression: giảm > tổng → 0); Thanh toán (tiền mặt kiểm tiền thối, thẻ, VietQR); Huỷ đơn (bắt buộc lý do); Tách hoá đơn; Báo cáo.
- [ ] Thanh toán tiền mặt: đưa dư → "Tiền thối"; đưa thiếu → "Còn thiếu" + chặn xác nhận.

**CRM khách hàng:** tìm kiếm (gõ là lọc ngay); Thêm/Lưu/ Sửa khách; double-click chi tiết.

**Tích điểm:** tìm theo SĐT; Đăng ký mới; **Tích điểm** (1 điểm/3.000đ — đã có unit test); Đổi điểm (chặn khi không đủ).

**Đặt bàn:** tìm kiếm + lọc trạng thái; Thêm; Sửa; Gửi nhắc; thẻ thống kê hôm nay/chờ/đã đến.

**Đặt tại bàn QR:** đổi bàn → QR đổi; "Giả lập" tạo đơn thật; đếm "đơn hôm nay" (Regression #2); In QR.

**Tiền mặt:** Bắt đầu/Kết thúc ca (chặn lặp); Báo cáo; double-click giao dịch.

### Barista
**Màn hình Bếp (KDS):** cột Chờ/Đang pha/Hoàn thành; nút "Bắt đầu pha"/"Hoàn thành" chuyển cột + lưu; Báo cáo.
**Công thức:** tìm kiếm; chọn công thức → nguyên liệu + các bước; double-click nguyên liệu.
**Cảnh báo NL:** chọn loại + gửi cảnh báo (thông báo tới QL); Báo cáo; double-click chi tiết.

### Security
**Bãi xe:** chọn loại xe; Xe vào (chặn khi đầy / thiếu biển số); Xe ra (chặn xe đã ra); ô trống cập nhật; Báo cáo.
**SOS:** nút SOS (xác nhận → tạo sự cố + báo QL); Báo cáo; double-click chi tiết.

### Dùng chung (mọi vai trò)
**Chấm công:** lọc theo NV (admin/QL) + khoảng ngày; nút Lọc; xuất báo cáo (Regression #9 cho nhân viên thường).
**Xin nghỉ:** gửi đơn (validate ngày — Regression #10); "Quản lý" (chỉ admin/QL); double-click lịch sử.
**Chọn ca / Đổi ca:** Nhận ca trống; Xin đổi ca; thẻ đếm ca của tôi/trống/chờ duyệt.
**Chat nội bộ / Hồ sơ cá nhân / Nhật ký:** mở được, không crash; tìm kiếm (nếu có) hoạt động.

---

### Ghi chú các điểm "design" đã biết (không phải bug, không sửa lần này)
- KDS cột "Hoàn thành" gom mọi đơn lịch sử (chưa lọc theo ngày) — cân nhắc lọc hôm nay nếu cần.
- "Chênh lệch" ở màn Tiền mặt luôn 0 (chưa có bước kiểm đếm tiền thực tế).
- Combo khuyến mãi hardcode "Tiết kiệm 15.000" — cần bổ sung ô nhập giá gốc nếu muốn chính xác.
- "Đóng vai Quản lý" (Admin) đổi vai trò trong session, chỉ khôi phục khi đăng nhập lại.
