using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearch.Persistence.Entities
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }
        [Column(TypeName = "Text")]
        public string Interests { get; set; }
    }
}
