using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Geographic
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PlaceCategory> PlaceCategories { get; set; }
    }
}
