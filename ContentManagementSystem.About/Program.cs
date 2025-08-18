using ContentManagementSystem.About;
using ContentManagementSystem.About.Repositories;
using ContentManagementSystem.About.Services.Abstracts;
using ContentManagementSystem.About.Services.Concretes;
using ContentManagementSystem.HomePage.Shared.DatabaseSettings;
using ContentManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddSettingsExt();
builder.Services.AddDatabaseServiceExt();
builder.Services.AddCommonServiceExt(typeof(AboutAssembly));
builder.Services.AddApiVersioningExt();
builder.Services.AddControllers();
builder.Services.AddScoped<IAboutService, AboutService>();

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
