using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Geographic
{
    public class PlaceCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
