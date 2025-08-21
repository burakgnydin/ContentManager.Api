using Castle.Core.Smtp;
using ContentManagementSystem.About.Services.Abstracts;
using ContentManagementSystem.About.Services.Concretes;
using ContentManagementSystem.Contact.Helper;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Contact.Services.Concretes;
using ContentManagementSystem.HomePage.Services.Abstracts;
using ContentManagementSystem.HomePage.Services.Concretes;
using MyEmail = ContentManagementSystem.Contact.Helper;

namespace App.Extensions
{
    public static class AddServiceExt
    {
        public static IServiceCollection AddServicesExt(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IContactFormService, ContactFormService>();
            services.AddScoped<IContactPageService, ContactPageService>();
            services.AddScoped<IHomePageService, HomePageService>();
            services.AddScoped<MyEmail.IEmailSender, EmailSender>();

            return services;
        }
    }
}
