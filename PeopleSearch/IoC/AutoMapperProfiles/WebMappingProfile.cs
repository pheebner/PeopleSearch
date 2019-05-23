using AutoMapper;

namespace PeopleSearch.IoC.AutoMapperProfiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Domain.Dto.Person, Models.Person>();
            CreateMap<Domain.Dto.Address, Models.Address>();
        }
    }
}
