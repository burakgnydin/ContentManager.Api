using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;

namespace ContentManagementSystem.HomePage.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Entities.HomePage> HomePages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.HomePage>(entity =>
            {
                entity.ToTable("HomePages");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired();

                entity.Property(e => e.ImageUrl);

                entity.Property(e => e.VideoUrl);

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.UpdatedDate);
            });
        }
    }
}