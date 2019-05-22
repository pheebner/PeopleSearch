using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleSearch.Domain.Dto;

namespace PeopleSearch.Business.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> SearchByNameAsync(string searchText);
    }
}