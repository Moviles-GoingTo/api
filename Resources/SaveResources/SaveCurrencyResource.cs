using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SaveCurrencyResource
    {
        [Required]
        [MaxLength(3)]
        public string ShortName { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
