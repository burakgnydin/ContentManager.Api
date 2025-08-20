namespace ContentManagementSystem.Blog.Entities.Dtos
{
    public class BlogDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
