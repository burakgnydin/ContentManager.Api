using Asp.Versioning.Builder;
using ContentManagementSystem.Blog.Features.Create;
using ContentManagementSystem.Blog.Features.Delete;
using ContentManagementSystem.Blog.Features.GetAll;
using ContentManagementSystem.Blog.Features.GetById;
using ContentManagementSystem.Blog.Features.Search;

namespace ContentManagementSystem.Blog.Features
{
    public static class BlogEndpointExt
    {
        public static void AddBlogGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/Blog").WithTags("Blogs").WithApiVersionSet(apiVersionSet)
               .CreateBlogGroupItemEndpint()
               .DeleteBlogGroupItemEndpint()
               .GetBlogByIdGroupItemEndpoint()
               .GetBlogsGroupItemEndpoint()
               .SearchBlogGroupItemEndpoint();
        }
    }
}
