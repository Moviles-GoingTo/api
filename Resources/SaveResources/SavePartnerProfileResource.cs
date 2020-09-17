using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources.SaveResources
{
    public class SavePartnerProfileResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
