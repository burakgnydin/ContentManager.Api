using ContentManagementSystem.Shared;

namespace ContentManagementSystem.About.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public History? History { get; set; }
        public List<Achievement>? Achievements { get; set; }

    }
}
