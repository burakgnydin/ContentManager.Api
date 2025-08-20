using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Shared;

namespace ContentManagementSystem.Contact.Services.Abstracts
{
    public interface IContactPageService
    {
        Task<ServiceResult> CreateContactPageAsync(CreateContactPageDto createContactPageDto, CancellationToken cancellationToken);
        Task<ServiceResult> UpdateContactPageAsync(UpdateContactPageDto updateContactPageDto, CancellationToken cancellationToken);
        Task<ServiceResult<ContactPageDto>> GetContactPageByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ServiceResult> DeleteContactPageAsync(Guid id, CancellationToken cancellationToken);

    }
}
