using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Domain.Dto;

namespace PeopleSearch.Persistence.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchText);
    }
}