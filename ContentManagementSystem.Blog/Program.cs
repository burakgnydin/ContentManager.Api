using ContentManagementSystem.Blog;
using ContentManagementSystem.Blog.Features;
using ContentManagementSystem.Blog.Repositories;
using ContentManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServiceExt(builder.Configuration);
builder.Services.AddCommonServiceExt(typeof(BlogAssembly));
builder.Services.AddApiVersioningExt();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(BlogAssembly)));

builder.Services.AddOpenApi();

var app = builder.Build();

app.AddBlogGroupEndpointExt(app.AddVersionSetExt());


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
