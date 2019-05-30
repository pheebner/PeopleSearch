using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60)]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [StringLength(9)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(55)]
        public string Country { get; set; }
    }
}
