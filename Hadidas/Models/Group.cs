namespace Hadidas.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public List<MessageUser>? MessageUsers { get; set; } = new();
    }
}
