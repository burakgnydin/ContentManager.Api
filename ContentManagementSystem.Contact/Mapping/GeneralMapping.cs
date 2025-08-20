using AutoMapper;
using ContentManagementSystem.Contact.Entities;
using ContentManagementSystem.Contact.Entities.Dtos;

namespace ContentManagementSystem.Contact.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ContactPageDto, ContactPage>().ReverseMap();
            CreateMap<CreateContactPageDto, ContactPage>().ReverseMap();
            CreateMap<ContactFormDto, ContactForm>().ReverseMap();
            CreateMap<SendContactFormDto, ContactForm>().ReverseMap();
        }
    }
}
