namespace ContentManagementSystem.About.Entities.Dtos
{
    public class AboutDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public History? History { get; set; }
        public List<Achievement>? Achievements { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
