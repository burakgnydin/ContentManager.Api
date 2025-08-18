using ContentManagementSystem.About.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContentManagementSystem.About.Repositories
{
    public class HistoryEntityConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToCollection("histories");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
