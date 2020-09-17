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
    }
}
