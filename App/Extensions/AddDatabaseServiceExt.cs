using Microsoft.EntityFrameworkCore;
using Nest;
using AboutDb = ContentManagementSystem.About.Repositories;
using BlogDb = ContentManagementSystem.Blog.Repositories;
using ContactDb = ContentManagementSystem.Contact.Repositories;
using HomePageDb = ContentManagementSystem.HomePage.Repositories;

namespace App.Extensions
{
    public static class AddDatabaseServiceExt
    {
        public static IServiceCollection AddDatabaseServicesExt(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");

            services.AddDbContext<AboutDb.AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<ContactDb.AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<HomePageDb.AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddDbContext<BlogDb.AppDbContext>(options =>
                options.UseNpgsql(connectionString));

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
