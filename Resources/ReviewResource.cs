using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class ReviewResource
    {
        public string Comment { get; set; }
        public float Stars { get; set; }
        public string ReviewedAt { get; set; }
        public LocatableResource Locatable { get; set; }
        public UserProfileResource UserProfile { get; set; }
    }
}
