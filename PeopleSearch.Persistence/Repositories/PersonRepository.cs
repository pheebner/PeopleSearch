using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPeopleSearchContext _peopleSearchContext;

        public PersonRepository(IPeopleSearchContext peopleSearchContext)
        {
            _peopleSearchContext = peopleSearchContext;
        }

        public async Task<IEnumerable<Person>> SearchByNameAsync(string searchText)
        {
            return await _peopleSearchContext.People
                .Include(p => p.Address)
                .Where(p => p.FirstName.Contains(searchText) || p.LastName.Contains(searchText))
                .ToListAsync();
        }
    }
}
