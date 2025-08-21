namespace App.Extensions
{
    public static class AddAutoMapperExt
    {
        public static IServiceCollection AddAutoMappersExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ContentManagementSystem.About.Mapping.GeneralMapping).Assembly,
                               typeof(ContentManagementSystem.HomePage.Mapping.GeneralMapping).Assembly,
                               typeof(ContentManagementSystem.Contact.Mapping.GeneralMapping).Assembly,
                               typeof(ContentManagementSystem.Blog.Mapping.GeneralMapping).Assembly);

            return services;
        }
    }
}
