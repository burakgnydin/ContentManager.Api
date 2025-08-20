using ContentManagementSystem.Shared;

namespace ContentManagementSystem.Contact.Entities
{
    public class ContactPage : BaseEntity
    {
        public string? Email { get; set; } 
        public string? OfficePhone { get; set; }
        public string? OficeAddress { get; set; } 
        public ContactForm? ContactForm { get; set; }
    }
}
