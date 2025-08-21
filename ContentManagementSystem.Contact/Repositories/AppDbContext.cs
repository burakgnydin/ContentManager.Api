using ContentManagementSystem.Contact.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;

namespace ContentManagementSystem.Contact.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ContactPage> ContactPages { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactPage>(entity =>
            {
                entity.ToTable("ContactPages");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Email);

                entity.Property(e => e.OfficePhone);

                entity.Property(e => e.OficeAddress);

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.UpdatedDate);
            });

            modelBuilder.Entity<ContactForm>(entity =>
            {
                entity.ToTable("ContactForms");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.SenderFullName)
                    .IsRequired();

                entity.Property(e => e.SenderEmail)
                    .IsRequired();

                entity.Property(e => e.SenderMessage)
                    .IsRequired();

                entity.Property(e => e.SenderPhone);

                entity.Property(e => e.CreatedDate);

                entity.Property(e => e.SendedDate);

            });
        }
    }
}
