using ContentManagementSystem.Contact.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ContentManagementSystem.Contact.Repositories
{
    public class ContactFormEntityConfiguration : IEntityTypeConfiguration<ContactForm>
    {
        public void Configure(EntityTypeBuilder<ContactForm> builder)
        {
            builder.ToCollection("contactForms");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.SenderFullName);
            builder.Property(x => x.SenderEmail);
            builder.Property(x => x.SenderMessage);
            builder.Property(x => x.SenderPhone);
            builder.Property(x => x.SendedDate);
        }
    }
}
