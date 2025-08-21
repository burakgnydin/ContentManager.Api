using ContentManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddAuthenticationAndAuthorizationExt(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "YARP (Gateway)");

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();


app.Run();