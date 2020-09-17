using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveReviewResource
    {
        [Required]
        [MaxLength(45)]
        public string Comment { get; set; }
        public int Stars { get; set; }
        public string ReviewedAt { get; set; }
    }
}
