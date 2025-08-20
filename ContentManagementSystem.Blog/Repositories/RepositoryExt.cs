using Microsoft.EntityFrameworkCore;
using Nest;
using ConnectionSettings = Nest.ConnectionSettings;

namespace ContentManagementSystem.Blog.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgres")));



            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
            });



            var esSettings = new ConnectionSettings(new Uri(configuration["Elasticsearch:Uri"]))
                .BasicAuthentication(configuration["Elasticsearch:Username"], configuration["Elasticsearch:Password"])
                .DefaultIndex("blogs");

            var esClient = new ElasticClient(esSettings);
            services.AddSingleton<IElasticClient>(esClient);

            return services;
        }
    }
}
