using AutoMapper;
using ContentManagementSystem.About.Entities;
using ContentManagementSystem.About.Entities.Dtos;

namespace ContentManagementSystem.About.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UpdateAboutDto, Entities.About>().ReverseMap();
            CreateMap<CreateAboutDto, Entities.About>().ReverseMap();
            CreateMap<AboutDto, Entities.About>().ReverseMap();

            CreateMap<AchievementDto, Achievement>().ReverseMap();

            CreateMap<HistoryDto, History>().ReverseMap();
        }
    }
}
