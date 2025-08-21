using Asp.Versioning;
using ContentManagementSystem.Contact.Entities.Dtos;
using ContentManagementSystem.Contact.Services.Abstracts;
using ContentManagementSystem.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.Contact.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ContactPageController(IContactPageService contactPageService, IContactFormService contactFormService) : ControllerBase
    {
        [HttpPost("create-contact-page")]
        public async Task<ActionResult<ServiceResult>> CreateContactPageAsync(CreateContactPageDto createContactPageDto, CancellationToken cancellationToken)
        {
            var result = await contactPageService.CreateContactPageAsync(createContactPageDto, cancellationToken);

            return Ok(result);
        }

        [HttpPut("update-contact-page")]
        public async Task<ActionResult<ServiceResult>> UpdateContactPageAsync(UpdateContactPageDto createContactPageDto, CancellationToken cancellationToken)
        {
            var result = await contactPageService.UpdateContactPageAsync(createContactPageDto, cancellationToken);

            return Ok(result);
        }

        [HttpGet("get-contact-page-by-id/{id:guid}")]
        public async Task<ActionResult<ServiceResult<ContactPageDto>>> GetContactPageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await contactPageService.GetContactPageByIdAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpDelete("delete-contact-page/{id:guid}")]
        public async Task<ActionResult<ServiceResult>> DeleteContactPageAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await contactPageService.DeleteContactPageAsync(id, cancellationToken);

            return Ok(result);
        }

        [HttpPost("send-contact-form")]
        public async Task<ActionResult<ServiceResult>> SendContactFormAsync(SendContactFormDto sendContactFormDto, CancellationToken cancellationToken)
        {
            var result = await contactFormService.SendContactFormAsync(sendContactFormDto, cancellationToken);

            return Ok(result);
        }
    }
}
