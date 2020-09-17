using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using GoingTo_API.Resources.SaveResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/plans")]
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;

        public PlansController(IPlanService planService, IMapper mapper)
        {
            _planService = planService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the plans in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlanResource>> GetAllAsync()
        {
            var plans = await _planService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Plan>,IEnumerable<PlanResource >> (plans);
            return resources;
        }
        /// <summary>
        /// creates a plan in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <response code="201">creates a plan in the system</response>
        /// <response code="400">unable to create the plan in the system due to validation</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlanResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.SaveAsync(plan);

            if (!result.Success)
                return BadRequest(result.Message);

            var planResouce = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResouce);
        }
        /// <summary>
        /// modify a plan in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SavePlanResource resource)
        {
            var plan = _mapper.Map<SavePlanResource, Plan>(resource);
            var result = await _planService.UpdateAsync(id, plan);

            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);
        }
        /// <summary>
        /// remove a plan in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var plan = _planService.GetByIdAsync(id);
            var result = await _planService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var planResource = _mapper.Map<Plan, PlanResource>(result.Resource);
            return Ok(planResource);

        }
    }
}
