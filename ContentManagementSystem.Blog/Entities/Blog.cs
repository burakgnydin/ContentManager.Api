using ContentManagementSystem.Shared;
using MediatR.NotificationPublishers;

namespace ContentManagementSystem.Blog.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Author {  get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
