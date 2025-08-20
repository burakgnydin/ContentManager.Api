using AutoMapper;
using ContentManagementSystem.Blog.Entities.Dtos;
using ContentManagementSystem.Blog.Extensions;
using ContentManagementSystem.Shared;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Nest;
using System.Net;
using System.Text.Json;

namespace ContentManagementSystem.Blog.Features.Search
{
    public record SearchBlogQuery(string SearchTerm) : IRequestByServiceResult<List<BlogDto>>;
    public class SearchBlogHandler(IElasticClient elasticClient, IDistributedCache cache) : IRequestHandler<SearchBlogQuery, ServiceResult<List<BlogDto>>>
    {
        public async Task<ServiceResult<List<BlogDto>>> Handle(SearchBlogQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"search_blogs_{request.SearchTerm}";

            var cached = await cache.GetStringAsync(cacheKey, cancellationToken);
            if (!string.IsNullOrEmpty(cached))
            {
                var cachedResult = JsonSerializer.Deserialize<List<BlogDto>>(cached);
                return ServiceResult<List<BlogDto>>.SuccessAsOk(cachedResult!);
            }

            var searchResponse = await elasticClient.SearchAsync<BlogDto>(s => s
                .Query(q => q
                    .MultiMatch(m => m
                        .Fields(f => f.Field(b => b.Title).Field(b => b.Content))
                        .Query(request.SearchTerm)
                        .Fuzziness(Fuzziness.Auto)
                    )
                )
                .Size(10),
                cancellationToken
            );

            if (!searchResponse.IsValid)
            {
                return ServiceResult<List<BlogDto>>.Error("ElasticSearch query failed", HttpStatusCode.InternalServerError);
            }

            var blogsDto = searchResponse.Documents.ToList();

            await cache.SetStringAsync(
                cacheKey,
                JsonSerializer.Serialize(blogsDto),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                },
                cancellationToken
            );

            return ServiceResult<List<BlogDto>>.SuccessAsOk(blogsDto);
        }
    }

    public static class SearchBlogEndpoint
    {
        public static RouteGroupBuilder SearchBlogGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/search-blog/{searchTerm}",
                    async (string searchTerm, IMediator mediator) =>
                        (await mediator.Send(new SearchBlogQuery(searchTerm))).ToGenericResult())
                .WithName("SearchBlog")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
