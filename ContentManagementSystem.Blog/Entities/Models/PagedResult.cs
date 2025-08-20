using ContentManagementSystem.Blog.Entities.Dtos;

namespace ContentManagementSystem.Blog.Entities.Models
{
    public class PagedResult
    {
        public List<BlogDto> Blogs { get; set; } = new List<BlogDto>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
