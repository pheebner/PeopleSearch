using System.Collections.Generic;
using PeopleSearch.Business.Models;

namespace PeopleSearch.Business.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> SearchByName(string searchText);
    }
}