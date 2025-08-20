using AutoMapper;
using ContentManagementSystem.Blog.Entities.Dtos;
using ContentManagementSystem.Blog.Extensions;
using ContentManagementSystem.Blog.Features.GetAll;
using ContentManagementSystem.Blog.Repositories;
using ContentManagementSystem.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Nest;
using System.Text.Json;

namespace ContentManagementSystem.Blog.Features.GetById
{
    public record GetBlogByIdQuery(Guid Id) : IRequestByServiceResult<BlogDto>;

    public class GetBlogByIdQueryHandler(AppDbContext context, IDistributedCache cache, IMapper mapper) : IRequestHandler<GetBlogByIdQuery, ServiceResult<BlogDto>>
    {
        public async Task<ServiceResult<BlogDto>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"blog_{request.Id}";

            var cached = await cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cached))
            {
                var cachedBlog = JsonSerializer.Deserialize<BlogDto>(cached);
                return ServiceResult<BlogDto>.SuccessAsOk(cachedBlog!);
            }


            var blog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

            if (blog == null)
            {
                return ServiceResult<BlogDto>.ErrorAsNotFound();
            }

            var blogDto = mapper.Map<BlogDto>(blog);

            await cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(blogDto),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                },
                cancellationToken
            );

            return ServiceResult<BlogDto>.SuccessAsOk(blogDto);
        }
    }

    public static class GetBlogByIdEndpoint
    {
        public static RouteGroupBuilder GetBlogByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/get-blog-by-id/{id:guid}",
                    async (Guid id, IMediator mediator) =>
                        (await mediator.Send(new GetBlogByIdQuery(id))).ToGenericResult())
                .WithName("GetBlogById")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
