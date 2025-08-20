using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Contact.Entities.Dtos
{
    public class UpdateContactPageDto
    {
        [Required]
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? OfficePhone { get; set; }
        public string? OficeAddress { get; set; }
    }
}
