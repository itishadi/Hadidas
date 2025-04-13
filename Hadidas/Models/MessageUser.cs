namespace Hadidas.Models
{
    public class MessageUser 
    {
        public int MessageUserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        public List<Message>? Messages { get; set; } // Meddelanden till denna användare
    }

}
