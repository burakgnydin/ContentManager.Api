using AutoMapper;
using ContentManagementSystem.About.Entities;
using ContentManagementSystem.About.Entities.Dtos;
using ContentManagementSystem.About.Repositories;
using ContentManagementSystem.About.Services.Abstracts;
using ContentManagementSystem.Shared;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ContentManagementSystem.About.Services.Concretes
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public AboutService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
       
        }

        public async Task<ServiceResult<CreateAboutDto>> CreateAboutAsync(CreateAboutDto createAboutDto, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Entities.About>(createAboutDto);

            var newHistory = new History()
            {
                Title = createAboutDto.History.Title,
                Description = createAboutDto.History.Description
            };

            var newAchievements = new List<Achievement>(_mapper.Map<List<Achievement>>(createAboutDto.Achievements));

            var newAbout = new Entities.About()
            {
                Id = NewId.NextSequentialGuid(),
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                History = newHistory,
                Achievements = newAchievements,
                CreatedDate = DateTime.UtcNow,
            };

            await _context.Abouts.AddAsync(newAbout, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateAboutDto>.SuccessAsCreated(createAboutDto, "<empty>");
        }

        public async Task<ServiceResult> DeleteAboutAsync(Guid id, CancellationToken cancellationToken)
        {
            var about = await _context.Abouts.FindAsync(id, cancellationToken);

            if (about is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();

        }

        public async Task<ServiceResult<AboutDto>> GetAboutByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (about is null)
            {
                return ServiceResult<AboutDto>.Error("About was not found", $"The about with id:{id} was not found", HttpStatusCode.NotFound);
            }

            var aboutAsDto = _mapper.Map<AboutDto>(about);
            return ServiceResult<AboutDto>.SuccessAsOk(aboutAsDto);
        }

        //public Task<ServiceResult<List<AboutDto>>> GetAboutsAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ServiceResult<PagedResult<AboutDto>>> GetAboutsByPaginationAsync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ServiceResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto, CancellationToken cancellationToken)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(x => x.Id == updateAboutDto.Id, cancellationToken);

            if (about is null)
            {
                return ServiceResult.ErrorAsNotFound();
            }

            about.Title = updateAboutDto.Title;
            about.Description = updateAboutDto.Description;
            about.Achievements = _mapper.Map<List<Achievement>>(updateAboutDto.Achievements);
            about.History = _mapper.Map<History>(updateAboutDto.History);
            about.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
