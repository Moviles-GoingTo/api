using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class CityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocatableResource Locatable { get; set; }
        public CountryResource Country { get; set; }

    }
}
