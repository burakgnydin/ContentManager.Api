using ContentManagementSystem.Blog.Extensions;
using ContentManagementSystem.Blog.Features.Create;
using ContentManagementSystem.Blog.Filters;
using ContentManagementSystem.Blog.Repositories;
using ContentManagementSystem.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Nest;
using System.Net;

namespace ContentManagementSystem.Blog.Features.Delete
{
    public record DeleteBlogCommand(Guid Id) : IRequestByServiceResult;

    public class DeleteBlogCommandHandler(AppDbContext context, IElasticClient elasticClient, IDistributedCache cache) : IRequestHandler<DeleteBlogCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await context.Blogs.FindAsync(request.Id, cancellationToken);

            if (blog == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.Blogs.Remove(blog);
            await context.SaveChangesAsync(cancellationToken);



            var esResponse = await elasticClient.DeleteAsync<Entities.Blog>(blog.Id, ct: cancellationToken);
            if (!esResponse.IsValid)
            {
                return ServiceResult.Error("Elasticsearch delete error", esResponse.OriginalException?.Message ?? "Unknown error", HttpStatusCode.InternalServerError);
            }


           
            await cache.RemoveAsync($"blog:{blog.Id}", cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }

    public static class DeleteBlogEndpoint
    {
        public static RouteGroupBuilder DeleteBlogGroupItemEndpint(this RouteGroupBuilder group)
        {
            group.MapDelete("/delete-blog/{id:guid}",
                    async (Guid id, IMediator mediator) =>
                        (await mediator.Send(new DeleteBlogCommand(id))).ToGenericResult())
                .WithName("DeleteBlog")
                .MapToApiVersion(1, 0);

            return group;
        }
    }
}
