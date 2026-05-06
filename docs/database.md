# Database Schema — Firebase Realtime Database

Base URL: `https://qlcafe-b621b-default-rtdb.asia-southeast1.firebasedatabase.app/`

---

## ID Naming Conventions

| Node | Prefix | Example |
|------|--------|---------|
| `nhan_vien` | `nv_` | `nv_001` |
| `mon_uong` | `mon_` | `mon_001` |
| `don_hang` | `dh_` | `dh_001` |
| `ban` | `ban_` | `ban_001` |
| `tin_nhan` | `msg_` (sub-key) | `msg_1713245000000` |
| `nguyen_lieu` | `nl_` | `nl_001` |
| `nhap_kho` | `nk_` | `nk_001` |
| `thanh_toan` | `tt_` | `tt_001` |
| `thong_bao` | `tb_` | `tb_001` |
| `xin_nghi` | `xn_` | `xn_001` |
| `feedback` | `fb_` | `fb_001` |
| `bai_xe` | `bx_` | `bx_001` |
| `su_co` | `sc_` | `sc_001` |
| `luong` | `luong_` | `luong_001` |
| `cong_thuc` | `ct_` | `ct_001` |
| `canh_bao` | `cb_` | `cb_001` |
| `khach_hang` | `kh_` | `kh_001` |
| `cham_cong` | `cc_` | `cc_001` |

---

## Nodes

### `/nhan_vien` — Nhân viên
```json
"nv_001": {
  "AuthUid": "firebase_auth_uid",
  "email": "nv@cafe.com",
  "ho_ten": "Nguyễn Văn A",
  "so_dien_thoai": "0901234567",
  "ngay_vao_lam": "2026-04-05",
  "avatar_url": "",
  "trang_thai": "active",       // "active" | "inactive"
  "vai_tro": "manager"          // "manager" | "admin" | "barista" | "order staff" | "security"
}
```

### `/mon_uong` — Thực đơn
```json
"mon_001": {
  "ten_mon": "Cà Phê Đen",
  "gia": 25000,
  "loai": "do_uong",            // "do_uong" | "tra" | "cafe"
  "mo_ta": "Cà phê đen đá không đường",
  "hinh_anh_url": "",
  "con_hang": true,
  "hien_thi": true
}
```

### `/ban` — Bàn
```json
"ban_001": {
  "ten_ban": "Bàn 1",
  "so_cho": 4,
  "trang_thai": "trong",        // "trong" | "co_khach" | "dat_truoc"
  "vi_tri": "Tầng 1"
}
```

### `/don_hang` — Đơn hàng
```json
"dh_001": {
  "ban_id": "ban_001",
  "nhanvien_id": "nv_001",
  "thoi_gian_tao": 1711900000000,
  "trang_thai": "pending",      // "pending" | "dang_phuc_vu" | "hoan_thanh" | "huy"
  "ghi_chu": "Khách yêu cầu mang ra nhanh",
  "chi_tiet_don": {
    "ctd_001": {
      "mon_id": "mon_001",
      "so_luong": 2,
      "don_gia": 25000,
      "ghi_chu_mon": "1 ly ít đá",
      "trang_thai_che_bien": "cho" // "cho" | "dang_lam" | "hoan_thanh"
    }
  }
}
```

### `/thanh_toan` — Thanh toán
```json
"tt_001": {
  "don_hang_id": "dh_001",
  "nhanvien_id": "nv_001",
  "phuong_thuc": "tien_mat",    // "tien_mat" | "momo" | "vnpay" | "card"
  "thoi_gian": 1711903600000,
  "tong_tien": 50000,
  "tien_giam": 0,
  "tien_thuc_thu": 50000
}
```

### `/nguyen_lieu` — Nguyên liệu
```json
"nl_001": {
  "ten_nguyen_lieu": "Cà phê hạt",
  "don_vi": "kg",
  "gia_nhap": 150000,
  "ton_kho": 15,
  "ton_kho_toi_thieu": 5
}
```

### `/nhap_kho` — Phiếu nhập kho
```json
"nk_001": {
  "nhanvien_id": "nv_001",
  "ngay_nhap": 1711900000000,   // Timestamp milliseconds
  "ghi_chu": "Nhập đầu tháng",
  "thanh_tien": 1500000,
  "ds_nl": {
    "nl_001": {
      "gia_nhap": 150000,
      "so_luong": 10,
      "thanh_tien": 1500000
    }
  }
}
```
> **Lưu ý:** `ngay_nhap` phải là timestamp ms, không phải DDMMYYYY.

### `/tin_nhan` — Tin nhắn chat
```json
"chat_nv_001_nv_002": {
  "msg_1713245000000": {
    "nguoi_gui_id": "nv_001",
    "noi_dung": "Xin chào!",
    "loai_tin_nhan": "text",    // "text" | "image"
    "thoi_gian": 1713245000000
  }
}
```
Room ID format: `chat_nv_{id1}_nv_{id2}` (sorted), hoặc `room_global`.

### `/thong_bao` — Thông báo
```json
"tb_001": {
  "loai": "don_moi",            // "don_moi" | "xin_nghi" | "sua_nguyen_lieu" | "feedback_xau" | "sos"
  "noi_dung": "Có đơn hàng mới tại Bàn 1",
  "nguoi_gui_id": "system",
  "nguoi_nhan_id": "nv_001",
  "thoi_gian": 1711900000000,
  "da_doc": false,
  "don_hang_id": "dh_001",
  "trang_lien_quan": "order"    // "order" | "leave" | "stock" | "feedback" | "security"
}
```

### `/xin_nghi` — Đơn xin nghỉ
```json
"xn_001": {
  "nhanvien_id": "nv_007",
  "tu_ngay": "15/04/2026",
  "den_ngay": "16/04/2026",
  "so_ngay": 2,
  "ly_do": "Việc gia đình",
  "trang_thai": "da_duyet",     // "cho_duyet" | "da_duyet" | "tu_choi"
  "thoi_gian_gui": 1744617600000,
  "nguoi_duyet_id": "nv_006",
  "thoi_gian_duyet": 1744624800000,
  "ghi_chu_duyet": ""
}
```

### `/cham_cong` — Chấm công
```json
"cc_001": {
  "nhanvien_id": "nv_001",
  "ngay": "2024-03-31",
  "gio_vao": 1711846800000,
  "gio_ra": 1711875600000,
  "so_gio_lam": 8,
  "trang_thai": "du_gio",       // "du_gio" | "di_muon" | "ve_som" | "nua_ca" | "nghi_phep" | "vang_mat"
  "ghi_chu": "Ca sáng"
}
```

### `/luong` — Bảng lương
```json
"luong_001": {
  "nhanvien_id": "nv_001",
  "thang": 4,
  "nam": 2026,
  "ngay_cong": 26,
  "luong_co_ban": 12000000,
  "phu_cap": 2000000,
  "thuong_feedback": 1500000,
  "thuong_le": 500000,
  "tru_luong": 0,               // Số dương: số tiền trừ
  "ly_do_tru": "",
  "tong_luong": 16000000,
  "trang_thai": "da_duyet",     // "chua_duyet" | "da_duyet"
  "ngay_tinh": 1746230400000
}
```

### `/feedback` — Phản hồi khách hàng
```json
"fb_001": {
  "ten_khach": "Lê Hồng Phúc",
  "so_sao": 5,                  // 1-5
  "noi_dung": "Đồ uống ngon!",
  "thoi_gian": 1746100000000,
  "da_xu_ly": true,
  "nguoi_xu_ly_id": "nv_006",
  "phan_hoi": "Cảm ơn quý khách!",
  "thoi_gian_phan_hoi": 1746103600000,
  "don_hang_id": "dh_001"
}
```

### `/bai_xe` — Bãi xe
```json
"bx_001": {
  "bien_so": "59A-12345",
  "loai_xe": "xe_may",          // "xe_may" | "o_to" | "xe_dap"
  "gio_vao": 1746146400000,
  "gio_ra": 0,                  // 0 = chưa ra
  "trang_thai": "dang_gui",     // "dang_gui" | "da_ra"
  "nhanvien_id": "nv_009",
  "phi_gui": 5000
}
```

### `/su_co` — Sự cố
```json
"sc_001": {
  "loai_su_co": "an_ninh",      // "an_ninh" | "y_te" | "ky_thuat" | "khac"
  "mo_ta": "Khách hàng gây rối",
  "nguoi_bao_id": "nv_009",
  "thoi_gian": 1746118200000,
  "trang_thai": "da_xu_ly",     // "cho_xu_ly" | "dang_xu_ly" | "da_xu_ly"
  "ghi_chu_xu_ly": "Đã xử lý",
  "muc_do": "khan_cap"          // "binh_thuong" | "nghiem_trong" | "khan_cap"
}
```

### `/cong_thuc` — Công thức pha chế
```json
"ct_001": {
  "ten_mon": "Cà phê sữa đá",
  "loai": "ca_phe",
  "mon_id": "mon_001",
  "cac_buoc": "1. Pha cà phê...",
  "nguyen_lieu": {
    "nl_ct_001": {
      "ten": "Cà phê phin",
      "dinh_luong": "25ml",
      "loai": "chinh",          // "chinh" | "phu" | "topping" | "trang_tri"
      "nguyen_lieu_id": "nl_001"
    }
  }
}
```

### `/canh_bao` — Cảnh báo hệ thống
```json
"cb_001": {
  "loai": "het_nguyen_lieu",    // "het_nguyen_lieu" | "sap_het" | "thiet_bi_hong"
  "noi_dung": "Sữa tươi đã hết",
  "nguoi_gui_id": "nv_008",
  "thoi_gian": 1746168600000,
  "trang_thai": "da_xu_ly",     // "cho_xu_ly" | "da_xu_ly"
  "nguyen_lieu_id": "nl_002"
}
```

### `/khach_hang` — Khách hàng
```json
"kh_001": {
  "ten_khach_hang": "Nguyễn Thị Lan",
  "so_dien_thoai": "0901234567",
  "email": "lan@email.com",
  "diem_tich_luy": 1520,
  "tong_don": 45,
  "ngay_tao": 1711900000000
}
```

### `/danh_sach_chat` — Danh sách hội thoại (index)
```json
"nv_001": {
  "chat_nv001_nv002": {
    "nguoi_nhan_id": "nv_002",
    "tin_nhan_cuoi": "Chào anh...",
    "thoi_gian_cuoi": 1711980000000,
    "da_doc": false
  }
}
```

---

## Data Consistency Rules

1. `ngay_nhap` trong `/nhap_kho` phải là **timestamp milliseconds**, không phải DDMMYYYY
2. `tru_luong` trong `/luong` phải là **số dương** (số tiền trừ), không âm
3. `AuthUid` trong `/nhan_vien` phải được điền khi tạo tài khoản Firebase Auth
4. Room ID chat format: `chat_nv_{smaller_id}_nv_{larger_id}` để tránh trùng
