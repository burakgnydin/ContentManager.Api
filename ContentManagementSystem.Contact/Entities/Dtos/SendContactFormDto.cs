using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Contact.Entities.Dtos
{
    public class SendContactFormDto
    {
        [Required]
        public string SenderFullName { get; set; } = null!;
        [Required]
        public string SenderEmail { get; set; } = null!;
        public string? SenderPhone { get; set; }
        [Required]
        public string SenderMessage { get; set; } = null!;
    }
}
