using AutoMapper;
using ContentManagementSystem.Contact.Entities;
using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Contact.Repositories;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Shared;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.Contact.Services.Concretes
{
    public class ContactPageService(AppDbContext context, IMapper mapper) : IContactPageService
    {
        public async Task<ServiceResult> CreateContactPageAsync(CreateContactPageDto createContactPageDto, CancellationToken cancellationToken)
        {

            var newContactPage = mapper.Map<ContactPage>(createContactPageDto);
            newContactPage.Id = NewId.NextSequentialGuid();
            newContactPage.CreatedDate = DateTime.UtcNow;

            await context.ContactPages.AddAsync(newContactPage, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        public async Task<ServiceResult> DeleteContactPageAsync(Guid id, CancellationToken cancellationToken)
        {
            var contactPage = await context.ContactPages.FindAsync(id, cancellationToken);

            if (contactPage is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            context.ContactPages.Remove(contactPage);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        public async Task<ServiceResult<ContactPageDto>> GetContactPageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var contactPage = await context.ContactPages.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (contactPage is null)
            {
                return ServiceResult<ContactPageDto>.ErrorAsNotFound();
            }

            var contactPageAsDto = mapper.Map<ContactPageDto>(contactPage);

            return ServiceResult<ContactPageDto>.SuccessAsOk(contactPageAsDto);
        }

        public async Task<ServiceResult> UpdateContactPageAsync(UpdateContactPageDto updateContactPageDto, CancellationToken cancellationToken)
        {
            var contactPage = await context.ContactPages.FirstOrDefaultAsync(x => x.Id == updateContactPageDto.Id, cancellationToken);

            if (contactPage is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            contactPage.OfficePhone = updateContactPageDto.OfficePhone;
            contactPage.OficeAddress = updateContactPageDto.OficeAddress;
            contactPage.Email = updateContactPageDto.Email;
            contactPage.UpdatedDate = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
