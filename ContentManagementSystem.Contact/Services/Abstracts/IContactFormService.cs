using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Shared;
using MongoDB.Driver;

namespace ContentManagementSystem.Contact.Services.Abstracts
{
    public interface IContactFormService
    {
        Task<ServiceResult> SendContactFormAsync(SendContactFormDto sendContactFormDto, CancellationToken cancellationToken);
    }
}
