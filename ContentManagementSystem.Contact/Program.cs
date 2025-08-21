using ContentManagementSystem.Contact;
using ContentManagementSystem.Contact.Helper;
using ContentManagementSystem.Contact.Repositories;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Contact.Services.Concretes;
using ContentManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServiceExt(builder.Configuration);
builder.Services.AddCommonServiceExt(typeof(ContactAssembly));
builder.Services.AddApiVersioningExt();
builder.Services.AddControllers();
builder.Services.AddContactServicesExt(builder.Configuration);
builder.Services.AddScoped<IContactPageService, ContactPageService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddAuthenticationAndAuthorizationExt(builder.Configuration);

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
