using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.HomePage.Entities.Dtos
{
    public class CreateHomePageDto
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
