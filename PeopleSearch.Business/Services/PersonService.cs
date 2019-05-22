using AutoMapper;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Models;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchText)
        {
            return (await _personRepository.SearchByNameAsync(searchText)).Select(p => _mapper.Map<Person>(p)).ToList();
        }
    }
}
