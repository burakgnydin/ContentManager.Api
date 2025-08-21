using Asp.Versioning;
using ContentManagementSystem.About.Entities.Dtos;
using ContentManagementSystem.About.Services.Abstracts;
using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.HomePage.Entities.Dtos;
using ContentManagementSystem.HomePage.Services.Abstracts;
using ContentManagementSystem.Shared;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IContactFormService _contactFormService;
        private readonly IContactPageService _contactPageService;
        private readonly IHomePageService _homePageService;
        //private readonly IBlogService _blogService;

        public AppController(IHomePageService homePageService, IContactFormService contactFormService, IContactPageService contactPageService, IAboutService aboutService)
        {
            _homePageService = homePageService;
            _aboutService = aboutService;
            _contactFormService = contactFormService;
            _contactPageService = contactPageService;
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

        [HttpPost("create-contact-page")]
        public async Task<ActionResult<ServiceResult>> CreateContactPageAsync(CreateContactPageDto createContactPageDto, CancellationToken cancellationToken)
        {
            var result = await _contactPageService.CreateContactPageAsync(createContactPageDto, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update-contact-page")]
        public async Task<ActionResult<ServiceResult>> UpdateContactPageAsync(UpdateContactPageDto createContactPageDto, CancellationToken cancellationToken)
        {
            var result = await _contactPageService.UpdateContactPageAsync(createContactPageDto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("get-contact-page-by-id/{id:guid}")]
        public async Task<ActionResult<ServiceResult<ContactPageDto>>> GetContactPageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _contactPageService.GetContactPageByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete-contact-page/{id:guid}")]
        public async Task<ActionResult<ServiceResult>> DeleteContactPageAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _contactPageService.DeleteContactPageAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpPost("send-contact-form")]
        public async Task<ActionResult<ServiceResult>> SendContactFormAsync(SendContactFormDto sendContactFormDto, CancellationToken cancellationToken)
        {
            var result = await _contactFormService.SendContactFormAsync(sendContactFormDto, cancellationToken);

            return Ok(result);
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

    }
}
