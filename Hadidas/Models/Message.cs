namespace Hadidas.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.Now;

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public int? MessageUserId { get; set; }
        public MessageUser? MessageUser { get; set; }
    }
}
