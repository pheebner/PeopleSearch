using System.Collections.Generic;

namespace PeopleSearch.Persistence.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }
        public ICollection<Interest> Interests { get; set; }
        public string PictureUrl { get; set; }
    }
}
