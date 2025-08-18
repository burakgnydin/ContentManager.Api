using ContentManagementSystem.About.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Text.Json;

namespace ContentManagementSystem.About.Repositories
{
    public class AboutEntityConfiguration : IEntityTypeConfiguration<Entities.About>
    {
        public void Configure(EntityTypeBuilder<Entities.About> builder)
        {
            builder.ToCollection("abouts");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title);  
            builder.Property(x => x.History)
            .HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<History>(v, (JsonSerializerOptions?)null));
            builder.Property(a => a.Achievements)
            .HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null), // null options ile netleştiriyoruz
            v => JsonSerializer.Deserialize<List<Achievement>>(v, (JsonSerializerOptions?)null) ?? new List<Achievement>());
            builder.Property(x => x.Description);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
