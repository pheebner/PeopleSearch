using AutoMapper;

namespace PeopleSearch.IoC.AutoMapperProfiles
{
    public class PersistenceMappingProfile : Profile
    {
        public PersistenceMappingProfile()
        {
            CreateMap<Persistence.Entities.Person, Domain.Dto.Person>();
            CreateMap<Persistence.Entities.Address, Domain.Dto.Address>();
        }
    }
}
