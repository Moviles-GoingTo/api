using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
    }
}
