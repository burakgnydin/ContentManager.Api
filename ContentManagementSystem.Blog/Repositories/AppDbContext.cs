using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.Blog.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options ) : DbContext(options)
    {
        public DbSet<Entities.Blog> Blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.Blog>(entity =>
            {
                entity.ToTable("Blogs");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Content)
                    .IsRequired();

                entity.Property(e => e.ImageUrl);

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.UpdatedDate);
            });
        }

    }
}
