using AutoMapper;
using ContentManagementSystem.Contact.Entities;
using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Contact.Helper;
using ContentManagementSystem.Contact.Repositories;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Shared;
using MassTransit;

namespace ContentManagementSystem.Contact.Services.Concretes
{
    public class ContactFormService(AppDbContext context, IEmailSender emailSender, IMapper mapper) : IContactFormService
    {
        public async Task<ServiceResult> SendContactFormAsync(SendContactFormDto sendContactFormDto, CancellationToken cancellationToken)
        {
            var newContactForm = mapper.Map<ContactForm>(sendContactFormDto);

            newContactForm.Id = NewId.NextSequentialGuid();
            newContactForm.CreatedDate = DateTime.UtcNow;

            await context.ContactForms.AddAsync(newContactForm,cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            var subject = $"Yeni iletişim formu: {sendContactFormDto.SenderFullName}";
            var body = $"Mesaj: {sendContactFormDto.SenderMessage}<br>E-mail: {sendContactFormDto.SenderEmail}";
            await emailSender.SendEmailAsync(sendContactFormDto.SenderEmail, subject, body, true);

            newContactForm.SendedDate = DateTime.UtcNow;
            await context.SaveChangesAsync(cancellationToken);


            return ServiceResult.SuccessAsNoContent();
        }
    }
}
