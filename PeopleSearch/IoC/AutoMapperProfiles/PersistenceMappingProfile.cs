using AutoMapper;

namespace PeopleSearch.IoC.AutoMapperProfiles
{
    public class PersistenceMappingProfile : Profile
    {
        public PersistenceMappingProfile()
        {
            CreateMap<Persistence.Entities.Person, Domain.Dto.Person>().ReverseMap()
                .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<Persistence.Entities.Address, Domain.Dto.Address>().ReverseMap()
                .ForMember(a => a.Id, opt => opt.Ignore())
                .ForMember(a => a.PersonId, opt => opt.Ignore());
        }
    }
}
