namespace GUI
{
    /// <summary>Dòng chi tiết đổ vào phiếu nhập (từ Excel/CSV).</summary>
    public readonly record struct InventoryImportPrefillLine(string NguyenLieuId, long SoLuong, long? GiaNhap);
}
