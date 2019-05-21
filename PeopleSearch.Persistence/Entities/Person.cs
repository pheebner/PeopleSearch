using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleSearch.Persistence.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Column(TypeName = "Text")]
        public string Interests { get; set; }
        [MaxLength(50)]
        public string PictureUrl { get; set; }
        public Address Address { get; set; }
    }
}
