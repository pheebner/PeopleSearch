using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearch.Persistence.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Person))]
        [Required]
        public int PersonId { get; set; }
        [MaxLength(60)]
        [Required]
        public string City { get; set; }
        [MaxLength(2)]
        [Required]
        public string State { get; set; }
        [MaxLength(100)]
        [Required]
        public string Street { get; set; }
        [MaxLength(9)]
        [Required]
        public string ZipCode { get; set; }
        [MaxLength(55)]
        [Required]
        public string Country { get; set; }
    }
}
