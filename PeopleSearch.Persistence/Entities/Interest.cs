using System.Collections.Generic;

namespace PeopleSearch.Persistence.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }
        public string Description { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
