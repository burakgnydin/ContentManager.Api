using Asp.Versioning;
using ContentManagementSystem.HomePage.Entities.Dtos;
using ContentManagementSystem.HomePage.Services.Abstracts;
using ContentManagementSystem.Shared;
using ContentManagementSystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.HomePage.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class HomePageController : ControllerBase
    {
        private readonly IHomePageService _homePageService;

        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [HttpPost("create-home-page")]
        public async Task<ActionResult<ServiceResult<CreateHomePageDto>>> CreateHomePageAsync(CreateHomePageDto createHomePageDto, CancellationToken cancellationToken)
        {
            var result = await _homePageService.CreateHomePageAsync(createHomePageDto, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update-home-page")]
        public async Task<ActionResult<ServiceResult>> UpdateHomePageAsync(UpdateHomePageDto updateHomePageDto, CancellationToken cancellationToken)
        {
            var result = await _homePageService.UpdateHomePageAsync(updateHomePageDto, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete-home-page/{id:guid}")]
        public async Task<ActionResult<ServiceResult>> DeleteHomePageAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _homePageService.DeleteHomePageAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpGet("get-home-page-by-id/{id:guid}")]
        public async Task<ActionResult<ServiceResult<HomePageDto>>> GetHomePageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _homePageService.GetHomePageByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        //[HttpGet("get-home-pages/")]
        //public async Task<ActionResult<ServiceResult<List<HomePageDto>>>> GetHomePagesAsync(CancellationToken cancellationToken)
        //{
        //    var result = await _homePageService.GetHomePagesAsync(cancellationToken);

        //    return Ok(result);
        //}

        //[HttpGet("get-home-pages-by-pagination/{page:int}")]
        //public async Task<ActionResult<ServiceResult<PagedResult>>> GetHomePagesByPaginationAsync(int page, CancellationToken cancellationToken)
        //{
        //    var result = await _homePageService.GetHomePagesByPaginationAsync(page,cancellationToken);

        //    return Ok(result);
        //}

    }
}
