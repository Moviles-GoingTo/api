using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route ("/api/plan/{planId}/benefits")]
    public class PlanBenefitsController : Controller
    {
        private readonly IPlanBenefitService _planBenefitService;
        private readonly IMapper _mapper;

        public PlanBenefitsController(IPlanBenefitService planBenefitService, IMapper mapper)
        {
            _planBenefitService = planBenefitService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the benefits from one plan in the system
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ViewPlanBenefitResource>> GetAllBenefitsByPlanId(int planId)
        {
            var benefits = await _planBenefitService.ListByPlanIdAsync(planId);
           var resources = _mapper.Map<IEnumerable<PlanBenefit>, IEnumerable<ViewPlanBenefitResource>>(benefits);

            return resources;
        }
        /// <summary>
        /// assign a benefit to a plan in the system
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="benefitId"></param>
        /// <returns></returns>
        [HttpPut("{benefitId}")]
        public async Task<IActionResult> AssignPlanBenefit(int planId, int benefitId)
        {
            var result = await _planBenefitService.AssignPlanBenefitAsync(planId, benefitId);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<PlanBenefit, PlanBenefitResource>(result.Resource);
            return Ok(planResource);
        }

        /// <summary>
        /// unnasign a benefit to a plan in the system
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="benefitId"></param>
        /// <returns></returns>
        [HttpDelete("{benefitId}")]
        public async Task<IActionResult> UnassignUserPlan(int planId, int benefitId)
        {
            var result = await _planBenefitService.UnassignPlanBenefitAsync(planId, benefitId);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<PlanBenefit, PlanBenefitResource>(result.Resource);
            return Ok(planResource);
        }
    }
}
