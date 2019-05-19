using System.Collections.Generic;

namespace PeopleSearch.Business.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Interests { get; set; }
        public string PictureUrl { get; set; }
    }
}
