using ContentManagementSystem.Contact.Repositories.DatabaseSettings;
using MongoDB.Driver;

namespace ContentManagementSystem.Contact.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var options = sp.GetRequiredService<MongoSettings>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var options = sp.GetRequiredService<MongoSettings>();

                return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
            });


            return services;
        }
    }
}
