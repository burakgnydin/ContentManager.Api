namespace ContentManagementSystem.Contact.Entities.Dtos
{
    public class ContactFormDto
    {
        public string? SenderFullName { get; set; } 
        public string? SenderEmail { get; set; } 
        public string? SenderPhone { get; set; }
        public string? SenderMessage { get; set; }

        public ContactFormDto(string senderFullName, string senderEmail, string senderPhone, string senderMessage)
        {
            SenderFullName = senderFullName;
            SenderEmail = senderEmail;
            SenderPhone = senderPhone;
            SenderMessage = senderMessage;
        }

        public static ContactFormDto Empty() { return new ContactFormDto(string.Empty, string.Empty, string.Empty, string.Empty); }
    }
}
