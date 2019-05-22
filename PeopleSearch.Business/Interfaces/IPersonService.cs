using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Business.Models;

namespace PeopleSearch.Business.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchText);
    }
}