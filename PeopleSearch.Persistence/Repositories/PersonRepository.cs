using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPeopleSearchContext _peopleSearchContext;

        public PersonRepository(IPeopleSearchContext peopleSearchContext)
        {
            _peopleSearchContext = peopleSearchContext;
        }

        public IEnumerable<Person> SearchByName(string searchText)
        {
            return _peopleSearchContext.People.Include(p => p.Interests)
                .Where(p => p.FirstName.Contains(searchText) || p.LastName.Contains(searchText))
                .ToList();
        }
    }
}
