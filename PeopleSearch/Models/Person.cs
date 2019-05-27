using PeopleSearch.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PeopleSearch.Models
{
    public class Person
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Age { get; set; }
        [Required]
        public string Interests { get; set; }
        [Required]
        [PersonImageUrl]
        [StringLength(50)]
        public string PictureUrl { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
