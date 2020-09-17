using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();

    }
}
