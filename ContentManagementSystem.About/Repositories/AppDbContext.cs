using ContentManagementSystem.About.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;
using System.Text.Json;

namespace ContentManagementSystem.About.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Entities.About> Abouts { get; set; }
        public DbSet<Achievement> Achievements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.About>(entity =>
            {
                entity.ToTable("Abouts");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(x => x.History)
            .HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<History>(v, (JsonSerializerOptions?)null));
                entity.Property(a => a.Achievements)
                .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<Achievement>>(v, (JsonSerializerOptions?)null) ?? new List<Achievement>());

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.UpdatedDate);
            });

            modelBuilder.Entity<Entities.Achievement>(entity =>
            {
                entity.ToTable("Achievements");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.UpdatedDate);
            });
        }
    }
}
