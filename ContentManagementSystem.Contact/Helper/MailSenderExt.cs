using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Contact.Services.Concretes;

namespace ContentManagementSystem.Contact.Helper
{
    public static class MailSenderExt
    {
        public static IServiceCollection AddContactServicesExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddScoped<IContactFormService, ContactFormService>();

            return services;
        }

    }
}
