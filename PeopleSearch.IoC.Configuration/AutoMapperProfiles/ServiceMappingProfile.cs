using AutoMapper;
using System.Linq;
using BusinessModels = PeopleSearch.Business.Models;
using Entities = PeopleSearch.Persistence.Entities;

namespace PeopleSearch.IoC.Configuration.AutoMapperProfiles
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Entities.Person, BusinessModels.Person>()
                .ForMember(dest => dest.Interests, options => options.MapFrom(src => src.Interests.Select(i => i.Description).ToList()));
            CreateMap<Entities.Address, BusinessModels.Address>();
        }
    }
}
