using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Business.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<Person> Search(string searchText)
        {
            //TODO wire up to database
            return Enumerable.Range(1, 10).Select(i => new Person
            {
                FirstName = nameof(Person.FirstName),
                LastName = nameof(Person.LastName),
                Address = new Address
                {
                    City = nameof(Address.City),
                    Street = nameof(Address.Street),
                    ZipCode = nameof(Address.ZipCode),
                    Country = nameof(Address.Country)
                },
                Age = i,
                Interests = Enumerable.Range(i, i + 10).Select(j => j.ToString()),
                PictureUrl = nameof(Person.PictureUrl)
            });
        }
    }
}
