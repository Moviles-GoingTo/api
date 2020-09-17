using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class PlanBenefitResource
    {
        public int BenefitId { get; set; }
        public int PlanId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
