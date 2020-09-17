using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class ViewPlanBenefitResource
    {
        public int BenefitId { get; set; }
        public BenefitResource Benefit { get; set; }
        public int PlanId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
