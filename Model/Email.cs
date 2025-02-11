namespace SendEmailAPI.Model
{
    public class Email
    {
        public string ToUser { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
