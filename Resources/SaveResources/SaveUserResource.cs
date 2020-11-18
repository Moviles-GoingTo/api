using System.ComponentModel.DataAnnotations;

namespace GoingTo_API.Resources
{
    public class SaveUserResource
    {
       

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(25)]
        public string BirthDate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(25)]
        public string CreatedAt { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}