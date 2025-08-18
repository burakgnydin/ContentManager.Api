using Asp.Versioning;
using ContentManagementSystem.About.Entities.Dtos;
using ContentManagementSystem.About.Services.Abstracts;
using ContentManagementSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ContentManagementSystem.About.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpPost("create-about")]
        public async Task<ActionResult<ServiceResult<CreateAboutDto>>> CreateAboutAsync(CreateAboutDto createAboutDto, CancellationToken cancellationToken)
        {
            var result = await _aboutService.CreateAboutAsync(createAboutDto, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update-about")]
        public async Task<ActionResult<ServiceResult>> UpdateAboutAsync(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken)
        {
            var result = await _aboutService.UpdateAboutAsync(updateAboutDto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("get-about-by-id/{id:guid}")]
        public async Task<ActionResult<ServiceResult<AboutDto>>> GetAboutByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _aboutService.GetAboutByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete-about/{id:guid}")]
        public async Task<ActionResult<ServiceResult>> DeleteAboutAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _aboutService.DeleteAboutAsync(id, cancellationToken);

            return Ok(result);
        }
    }
}
