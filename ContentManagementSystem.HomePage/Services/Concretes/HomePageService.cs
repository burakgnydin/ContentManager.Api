using AutoMapper;
using ContentManagementSystem.HomePage.Entities.Dtos;
using ContentManagementSystem.HomePage.Repositories;
using ContentManagementSystem.HomePage.Services.Abstracts;
using ContentManagementSystem.Shared;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Net;

namespace ContentManagementSystem.HomePage.Services.Concretes
{
    public class HomePageService : IHomePageService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public HomePageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CreateHomePageDto>> CreateHomePageAsync(CreateHomePageDto createHomePageDto, CancellationToken cancellationToken)
        {
            var newHomePage = _mapper.Map<Entities.HomePage>(createHomePageDto);
            newHomePage.Id = NewId.NextSequentialGuid();
            newHomePage.CreatedDate = DateTime.UtcNow;

            await _context.HomePages.AddAsync(newHomePage, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateHomePageDto>.SuccessAsCreated(createHomePageDto, "<empty>");
        }

        public async Task<ServiceResult> DeleteHomePageAsync(Guid id, CancellationToken cancellationToken)
        {
            var hasHomePage = await _context.HomePages.FindAsync([id], cancellationToken);
            if (hasHomePage is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            _context.HomePages.Remove(hasHomePage);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        public async Task<ServiceResult<HomePageDto>> GetHomePageByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var hasHomePage = await _context.HomePages.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (hasHomePage is null)
            {
                return ServiceResult<HomePageDto>.Error("Home page was not found", $"The home page with id:{id} was not found", HttpStatusCode.NotFound);
            }

            var homePageAsDto = _mapper.Map<HomePageDto>(hasHomePage);
            return ServiceResult<HomePageDto>.SuccessAsOk(homePageAsDto);
        }

        public async Task<ServiceResult> UpdateHomePageAsync(UpdateHomePageDto updateHomePageDto, CancellationToken cancellationToken)
        {
            var value = await _context.HomePages.FirstOrDefaultAsync(x => x.Id == updateHomePageDto.Id, cancellationToken);

            if (value == null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            value.Title = updateHomePageDto.Title;
            value.Description = updateHomePageDto.Description;
            value.VideoUrl = updateHomePageDto.VideoUrl;
            value.ImageUrl = updateHomePageDto.ImageUrl;
            value.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
