using ContentManagementSystem.About.Entities.Dtos;
using ContentManagementSystem.Shared;

namespace ContentManagementSystem.About.Services.Abstracts
{
    public interface IAboutService
    {
        Task<ServiceResult<CreateAboutDto>> CreateAboutAsync(CreateAboutDto createAboutDto, CancellationToken cancellationToken);
        Task<ServiceResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken);
        Task<ServiceResult> DeleteAboutAsync(Guid id, CancellationToken cancellationToken);
        Task<ServiceResult<AboutDto>> GetAboutByIdAsync(Guid id, CancellationToken cancellationToken);

        //Task<ServiceResult<List<AboutDto>>> GetAboutsAsync(CancellationToken cancellationToken);
        //Task<ServiceResult<PagedResult<AboutDto>>> GetAboutsByPaginationAsync(CancellationToken cancellationToken);
    }
}
