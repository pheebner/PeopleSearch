using System.Collections.Generic;

namespace PeopleSearch.Persistence.Entities
{
    public class Interest
    {
        public Interest()
        {
            People = new HashSet<Person>();
        }

        public int InterestId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
