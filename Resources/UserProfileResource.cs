using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class UserProfileResource
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; }
        public CountryResource Country { get; set; }
    }
}
