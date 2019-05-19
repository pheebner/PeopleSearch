using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Persistence.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        [MaxLength(60)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        [MaxLength(9)]
        public string ZipCode { get; set; }
        [MaxLength(55)]
        public string Country { get; set; }
    }
}
