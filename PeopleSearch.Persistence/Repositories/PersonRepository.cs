using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PeopleSearch.Domain.Dto;

namespace PeopleSearch.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPeopleSearchContext _peopleSearchContext;
        private readonly IMapper _mapper;

        public PersonRepository(IPeopleSearchContext peopleSearchContext, IMapper mapper)
        {
            _peopleSearchContext = peopleSearchContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchText)
        {
            return (await _peopleSearchContext.People
                .Include(p => p.Address)
                .Where(p => p.FirstName.Contains(searchText) || p.LastName.Contains(searchText))
                .ToListAsync())
                .Select(p => _mapper.Map<Person>(p)).ToList();
        }
    }
}
