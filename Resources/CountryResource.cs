using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class CountryResource
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public LocatableResource Locatable { get; set; }
    }
}
