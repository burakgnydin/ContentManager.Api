using ContentManagementSystem.Contact.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Text.Json;

namespace ContentManagementSystem.Contact.Repositories
{
    public class ContactPageEntityConfiguration : IEntityTypeConfiguration<ContactPage>
    {
        public void Configure(EntityTypeBuilder<ContactPage> builder)
        {
            builder.ToCollection("contactPages");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Email);
            builder.Property(x => x.OficeAddress);
            builder.Property(x => x.ContactForm)
                 .HasConversion(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
            v => JsonSerializer.Deserialize<ContactForm>(v, (JsonSerializerOptions?)null));
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.UpdatedDate);
        }
    }
}
