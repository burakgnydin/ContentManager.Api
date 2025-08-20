using ContentManagementSystem.Blog.Extensions;
using ContentManagementSystem.Blog.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Blog.Features.Create
{
    public static class CreateBlogEndpoint
    {
        public static RouteGroupBuilder CreateBlogGroupItemEndpint(this RouteGroupBuilder group)
        {
            group.MapPost("/create-blog",
                    async (CreateBlogCommand command, IMediator mediator) =>
                        (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateBlog")
                .MapToApiVersion(1, 0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError)
                .AddEndpointFilter<ValidationFilter<CreateBlogCommand>>();

            return group;
        }
    }
}
