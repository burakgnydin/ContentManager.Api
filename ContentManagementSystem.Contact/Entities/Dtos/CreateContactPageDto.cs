using System.Text.Json.Serialization;

namespace ContentManagementSystem.Contact.Entities.Dtos
{
    public class CreateContactPageDto
    {
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public string? OficeAddress { get; set; }
        [JsonIgnore] public ContactFormDto ContactForm { get; set; } = ContactFormDto.Empty();
    }
}
