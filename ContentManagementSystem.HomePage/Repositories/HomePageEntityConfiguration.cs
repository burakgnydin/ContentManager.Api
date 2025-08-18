using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContentManagementSystem.HomePage.Repositories
{
    public class HomePageEntityConfiguration : IEntityTypeConfiguration<Entities.HomePage>
    {
        public void Configure(EntityTypeBuilder<Entities.HomePage> builder)
        {
            builder.ToCollection("homePages");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.VideoUrl);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}