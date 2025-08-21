using ContentManagementSystem.HomePage;
using ContentManagementSystem.HomePage.Repositories;
using ContentManagementSystem.HomePage.Services.Abstracts;
using ContentManagementSystem.HomePage.Services.Concretes;
using ContentManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServiceExt(builder.Configuration);
builder.Services.AddCommonServiceExt(typeof(HomePageAssembly));
builder.Services.AddApiVersioningExt();
builder.Services.AddControllers();
builder.Services.AddScoped<IHomePageService, HomePageService>();

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
