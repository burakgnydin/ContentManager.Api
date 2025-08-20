using ContentManagementSystem.Blog.Entities.Dtos;
using ContentManagementSystem.Shared;

namespace ContentManagementSystem.Blog.Features.Create
{
    public record CreateBlogCommand(string Title, string Content, string Author, string? ImageUrl)  : IRequestByServiceResult<BlogDto>;
}
