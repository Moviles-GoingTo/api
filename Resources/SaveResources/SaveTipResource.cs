using System;
using System.ComponentModel.DataAnnotations;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Resources
{
    public class SaveTipResource
    {
        [Required]
//<<<<<<< HEAD
//        [MaxLength(140)]
//=======
        [MaxLength(45)]
//>>>>>>> 4fe95f5... Fix en resources 2
        public string Text { get; set; }
    }
}
