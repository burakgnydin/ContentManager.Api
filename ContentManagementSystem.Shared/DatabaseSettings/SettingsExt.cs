using ContentManagementSystem.Shared.DatabaseSettings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ContentManagementSystem.HomePage.Shared.DatabaseSettings
{
    public static class SettingsExt
    {
        public static IServiceCollection AddSettingsExt(this IServiceCollection services)
        {
            services.AddOptions<MongoSettings>().BindConfiguration(nameof(MongoSettings)).ValidateDataAnnotations()
                .ValidateOnStart();


            services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoSettings>>().Value);


            return services;
        }
    }
}