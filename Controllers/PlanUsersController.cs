using AutoMapper;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Accounts;
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
    [Route("/api/plan/{planId}/user/{userId}")]
    public class PlanUsersController : Controller
    {
        private readonly IUserPlanService _userPlanService;
        private readonly IMapper _mapper;

        public PlanUsersController(IUserPlanService userPlanService, IMapper mapper)
        {
            _userPlanService = userPlanService;
            _mapper = mapper;
        }

        /// <summary>
        /// assign a plan to an user in the system
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> AssignUserPlan(int userId, int planId)
        {
            var result = await _userPlanService.AssignUserPlanAsync(userId, planId);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource.Plan);
            return Ok(planResource);
        } 


        /// <summary>
        /// unnasign a plan to an user in the system
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> UnassignUserPlan(int userId, int planId)
        {
            var result = await _userPlanService.UnassignUserPlanAsync(userId, planId);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource.Plan);
            return Ok(planResource);
        }

    }
}
