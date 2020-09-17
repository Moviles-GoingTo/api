using GoingTo_API.Domain.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Stars { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public List<PlaceCategory> PlaceCategories { get; set; }
    }
}
