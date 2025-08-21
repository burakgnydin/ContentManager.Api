using App;
using App.Extensions;
using ContentManagementSystem.Blog;
using ContentManagementSystem.Blog.Features;
using ContentManagementSystem.Shared.Extensions;
using Serilog;
using Serilog.Sinks.Grafana.Loki;

var builder = WebApplication.CreateBuilder(args);

var labels = new List<LokiLabel>
{
    new LokiLabel { Key = "app", Value = "cms" },
    new LokiLabel { Key = "environment", Value = "development" }
};

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.GrafanaLoki("http://localhost:3100", labels)
    .CreateLogger();

builder.Host.UseSerilog();

try
{
    Log.Information("CMS is starting");

    builder.Services.AddSwaggerGen();
    builder.Services.AddCommonServiceExt(typeof(AppAssembly));
    builder.Services.AddApiVersioningExt();
    builder.Services.AddControllers();
    builder.Services.AddDatabaseServicesExt(builder.Configuration);
    builder.Services.AddAutoMappersExt();
    builder.Services.AddOpenApi();
    builder.Services.AddServicesExt();
    builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(BlogAssembly)));

    var app = builder.Build();

    app.AddBlogGroupEndpointExt(app.AddVersionSetExt());

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "CMS could not started");
}
finally
{
    Log.CloseAndFlush();
}

