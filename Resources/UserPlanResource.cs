using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class UserPlanResource
    {
        public int UserId { get; set; }
        public int PlaId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
