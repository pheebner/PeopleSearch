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
            CreateMap<Entities.Person, BusinessModels.Person>();
            CreateMap<Entities.Address, BusinessModels.Address>();
        }
    }
}
