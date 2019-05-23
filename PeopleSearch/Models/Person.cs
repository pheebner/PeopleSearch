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
        public int Age { get; set; }
        [Required]
        public string Interests { get; set; }
        [Url]
        [StringLength(50)]
        public string PictureUrl { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
