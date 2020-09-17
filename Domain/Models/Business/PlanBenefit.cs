using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class PlanBenefit
    {
        public int Id { get; set; }
        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
