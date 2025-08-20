using AutoMapper;
using ContentManagementSystem.Blog.Entities.Dtos;

namespace ContentManagementSystem.Blog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<BlogDto, Entities.Blog>().ReverseMap();
        }
    }
}
