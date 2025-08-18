using AutoMapper;
using ContentManagementSystem.HomePage.Entities;
using ContentManagementSystem.HomePage.Entities.Dtos;

namespace ContentManagementSystem.HomePage.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateHomePageDto, Entities.HomePage>().ReverseMap();
            CreateMap<UpdateHomePageDto, Entities.HomePage>().ReverseMap();
            CreateMap<HomePageDto, Entities.HomePage>().ReverseMap();
        }
    }
}
