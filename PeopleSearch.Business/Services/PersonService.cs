using PeopleSearch.Business.Interfaces;
using PeopleSearch.Domain.Dto;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleSearch.Business.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchText) => await _personRepository.SearchByNameAsync(searchText);
        public async Task CreatePersonAsync(Person person) => await _personRepository.CreatePersonAsync(person);
    }
}
