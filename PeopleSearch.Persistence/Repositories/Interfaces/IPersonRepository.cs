using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Persistence.Entities;

namespace PeopleSearch.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchText);
    }
}