using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;
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
    [Route ("/api/benefits")]
    public class BenefitsController : Controller
    {
        private readonly IBenefitService _benefitService;
        private readonly IMapper _mapper;

        public BenefitsController(IBenefitService benefitService, IMapper mapper)
        {
            _benefitService = benefitService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the benefits in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<BenefitResource>>  GetAllAsync()
        {
            var benefits = await _benefitService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Benefit>, IEnumerable<BenefitResource>>(benefits);

            return resource;
        }


        /// <summary>
        /// add a benefit in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveBenefitResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var benefit = _mapper.Map<SaveBenefitResource, Benefit>(resource);
            var result = await _benefitService.SaveAsync(benefit);

            if (!result.Success)
                return BadRequest(result.Message);

            var benefitResource = _mapper.Map<Benefit, BenefitResource>(result.Resource);
            return Ok(benefitResource);
        }

        /// <summary>
        /// modify a benefit in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBenefitResource resource)
        {
            var benefit = _mapper.Map<SaveBenefitResource, Benefit>(resource);
            var result = await _benefitService.UpdateAsync(id, benefit);

            if (!result.Success)
                return BadRequest(result.Message);

            var benefitResource = _mapper.Map<Benefit, BenefitResource>(result.Resource);
            return Ok(benefitResource);
        }

        /// <summary>
        /// remove a benefit from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _benefitService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var benefitResource = _mapper.Map<Benefit, BenefitResource>(result.Resource);
            return Ok(benefitResource);
        }
    }
}
