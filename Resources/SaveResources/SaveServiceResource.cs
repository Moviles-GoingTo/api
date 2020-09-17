using System;
using System.ComponentModel.DataAnnotations;

namespace GoingTo_API.Resources.SaveResources
{
    public class SaveServiceResource
    {
        [Required]
        [MaxLength (45)]
        public string Name { get; set; }
    }
}
