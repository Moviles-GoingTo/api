using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PlanBenefit> PlanBenefits { get; set; }
    }
}
