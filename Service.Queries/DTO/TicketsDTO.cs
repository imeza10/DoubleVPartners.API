namespace Domain
{
    public class TicketsDTO
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string? User { get; set; }
        public required bool Status { get; set; }
        public string? StatusDescriptions { get; set; }
        public DateTime AddAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
