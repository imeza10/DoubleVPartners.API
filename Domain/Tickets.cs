namespace Domain
{
    public class Tickets
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public required bool Status { get; set; }
        public DateTime AddAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Users? UsersNavigation { get; set; }
    }
}
