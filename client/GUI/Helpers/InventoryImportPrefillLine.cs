namespace GUI
{
    // Dòng chi tiết đổ vào phiếu nhập (từ Excel/CSV).
    public readonly record struct InventoryImportPrefillLine(string NguyenLieuId, long SoLuong, long? GiaNhap);
}
