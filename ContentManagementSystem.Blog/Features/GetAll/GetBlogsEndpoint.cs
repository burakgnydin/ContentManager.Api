using AutoMapper;
using ContentManagementSystem.Blog.Entities.Dtos;
using ContentManagementSystem.Blog.Entities.Models;
using ContentManagementSystem.Blog.Extensions;
using ContentManagementSystem.Blog.Repositories;
using ContentManagementSystem.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace ContentManagementSystem.Blog.Features.GetAll
{
    public record GetBlogsQuery(int PageNumber) : IRequestByServiceResult<PagedResult>;

    public class GetBlogsQueryHandler(AppDbContext context, IDistributedCache cache, IMapper mapper) : IRequestHandler<GetBlogsQuery, ServiceResult<PagedResult>>
    {
        public async Task<ServiceResult<PagedResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"blogs_page_{request.PageNumber}";

            var cached = await cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cached))
            {
                var cachedBlogs = JsonSerializer.Deserialize<PagedResult>(cached);
                return ServiceResult<PagedResult>.SuccessAsOk(cachedBlogs!);
            }

            var pageSize = 3f;
            var totalBlogs = await context.Blogs.CountAsync(cancellationToken);
            var pageCount = Math.Ceiling(totalBlogs / pageSize);

            var blogsResultDto = await context.Blogs
                .OrderBy(b => b.Id)
                .Skip((request.PageNumber - 1) * (int)pageSize)
                .Take((int)pageSize)
                .Select(b => mapper.Map<BlogDto>(b))
                .ToListAsync(cancellationToken);

            var pagedResult = new PagedResult()
            {
                Blogs = blogsResultDto,
                Pages = (int)pageCount,
                CurrentPage = request.PageNumber
            };

            await cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(pagedResult),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                },
                cancellationToken
            );

            return ServiceResult<PagedResult>.SuccessAsOk(pagedResult);
        }

    }

    public static class GetBlogsEndpoint
    {
        public static RouteGroupBuilder GetBlogsGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/get-blogs/{pageNumber:int}",
                    async (int pageNumber, IMediator mediator) =>
                        (await mediator.Send(new GetBlogsQuery(pageNumber))).ToGenericResult())
                .WithName("GetBlogs")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
