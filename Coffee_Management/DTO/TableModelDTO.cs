namespace DTO
{
    public class MoHinhBanDTO
    {
        public int TableId { get; set; }
        public string? TableName { get; set; }
        public string? Status { get; set; }
        public string? Progress { get; set; }
        public string? TotalAmount { get; set; }
    }

    public class TableModelDTO : MoHinhBanDTO
    {
    }
}
