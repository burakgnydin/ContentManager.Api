using ContentManagementSystem.Shared;

namespace ContentManagementSystem.Contact.Entities
{
    public class ContactForm 
    {
        public Guid Id { get; set; }
        public string SenderFullName { get; set; } = null!;
        public string SenderEmail { get; set; } = null!;
        public string? SenderPhone { get; set; }
        public string SenderMessage { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime SendedDate { get; set; }
     }
}
