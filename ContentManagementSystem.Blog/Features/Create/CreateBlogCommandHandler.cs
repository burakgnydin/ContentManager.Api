using AutoMapper;
using ContentManagementSystem.Blog.Entities.Dtos;
using ContentManagementSystem.Blog.Repositories;
using ContentManagementSystem.Shared;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Nest;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;

namespace ContentManagementSystem.Blog.Features.Create
{
    public class CreateBlogCommandHandler(AppDbContext context, IElasticClient elasticClient, IMapper mapper, IDistributedCache  cache) : IRequestHandler<CreateBlogCommand, ServiceResult<BlogDto>>
    {

        public async Task<ServiceResult<BlogDto>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var newBlog = new Entities.Blog()
            {
                Id = NewId.NextSequentialGuid(),
                Title = request.Title,
                Content = request.Content,
                Author = request.Author,
                ImageUrl = request.ImageUrl,
                CreatedDate = DateTime.UtcNow
            };

            await context.Blogs.AddAsync(newBlog, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);



            var indexResponse = await elasticClient.IndexDocumentAsync(newBlog, cancellationToken);

            if (!indexResponse.IsValid)
            {
                return ServiceResult<BlogDto>.Error(
                                                    "Elasticsearch Index Error",
                                                     indexResponse.OriginalException?.Message ?? "Unknown error",
                                                        HttpStatusCode.InternalServerError);
            }


            var cacheKey = $"blog:{newBlog.Id}";
            var cacheData = JsonSerializer.Serialize(newBlog);
            await cache.SetStringAsync(cacheKey, cacheData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            }, cancellationToken);



            var blogAsDto = mapper.Map<BlogDto>(newBlog);

            return ServiceResult<BlogDto>.SuccessAsCreated(blogAsDto, "<empty>");
        }
    }
}
