using System.ComponentModel.DataAnnotations;

namespace GoingTo_API.Resources
{
    public class SaveProfileResource
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MaxLength (45)]
        public string Surname { get; set; }

        public string BirthDate { get; set; }

        [MaxLength(6)]
        public string Gender { get; set; }

        public string CreatedAt { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
