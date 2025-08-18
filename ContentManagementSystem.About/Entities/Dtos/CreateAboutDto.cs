using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.About.Entities.Dtos
{
    public class CreateAboutDto
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public HistoryDto? History { get; set; }
        public List<AchievementDto>? Achievements { get; set; }

    }
}
