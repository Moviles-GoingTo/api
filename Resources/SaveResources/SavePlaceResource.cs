using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class SavePlaceResource
    {
        [Required]
        public int CityId { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        [Required]
        public int LocatableId { get; set; }
    }
}
