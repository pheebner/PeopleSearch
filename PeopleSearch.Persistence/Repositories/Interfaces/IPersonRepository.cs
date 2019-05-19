using System.Collections.Generic;
using PeopleSearch.Persistence.Entities;

namespace PeopleSearch.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> SearchByName(string searchText);
    }
}