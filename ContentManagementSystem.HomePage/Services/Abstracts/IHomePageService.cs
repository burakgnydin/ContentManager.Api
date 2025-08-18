using ContentManagementSystem.HomePage.Entities.Dtos;
using ContentManagementSystem.Shared;
using ContentManagementSystem.Shared.Models;

namespace ContentManagementSystem.HomePage.Services.Abstracts
{
    public interface IHomePageService
    {
        Task<ServiceResult<CreateHomePageDto>> CreateHomePageAsync(CreateHomePageDto createHomePageDto, CancellationToken cancellationToken);
        Task<ServiceResult> UpdateHomePageAsync(UpdateHomePageDto updateHomePageDto, CancellationToken cancellationToken);
        Task<ServiceResult> DeleteHomePageAsync(Guid id, CancellationToken cancellationToken);
        Task<ServiceResult<HomePageDto>> GetHomePageByIdAsync(Guid id, CancellationToken cancellationToken);

        //Task<ServiceResult<List<HomePageDto>>> GetHomePagesAsync(CancellationToken cancellationToken);
        //Task<ServiceResult<PagedResult<HomePageDto>>> GetHomePagesByPaginationAsync(int page, CancellationToken cancellationToken);

        //PublishHomePage(id) 

        //UnpublishHomePage(id) 

        //GetHomePageVersions(id) 

        //RollbackHomePage(id, versionId) 
    }
}
