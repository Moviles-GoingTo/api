using GoingTo_API.Domain.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlanBenefit> PlanBenefits { get; set; }
        public List<PlanUser> PlanUsers { get; set; }
    }
}
