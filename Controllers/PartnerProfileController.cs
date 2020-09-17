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
    [Route ("/api/PartnerProfile")]
    public class PartnerProfileController : Controller
    {
        private readonly IPartnerProfileService _partnerProfileService;
        private readonly IMapper _mapper;

        public PartnerProfileController(IPartnerProfileService partnerProfileService, IMapper mapper)
        {
            _partnerProfileService = partnerProfileService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns a partner profile by partnerId
        /// </summary>
        /// <param name="partnerId"></param>
        /// <response code="200">return a partner profile</response>
        /// <returns></returns>
        [HttpGet("{partnerId}")]
        public async Task<IActionResult> GetByPartnerId(int partnerId)
        {
            var result = await _partnerProfileService.GetByPartnerIdAsync(partnerId);
            if (!result.Success)
                return BadRequest(result.Message);
            var partnerProfileResource = _mapper.Map<PartnerProfile, PartnerProfileResource>(result.Resource);
            return Ok(partnerProfileResource);
        }
        /// <summary>
        /// create a partner profile in the system.
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("{partnerId}")]
        public async Task<IActionResult> PostAsync(int partnerId,[FromBody] SavePartnerProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var partnerProfile = _mapper.Map<SavePartnerProfileResource, PartnerProfile>(resource);
                partnerProfile.PartnerId = partnerId;
            var result = await _partnerProfileService.SaveAsync(partnerProfile);

            if (!result.Success)
                return BadRequest(result.Message);

            var partnerProfileResource = _mapper.Map<PartnerProfile, PartnerProfileResource>(result.Resource);
            return Ok(partnerProfileResource);
        }
        /// <summary>
        /// modify a partner profile in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartnerProfile(int id, [FromBody] SavePartnerProfileResource resource)
        {
            var partnerProfile = _mapper.Map<SavePartnerProfileResource, PartnerProfile>(resource);
            var result = await _partnerProfileService.UpdateAsync(id, partnerProfile);

            if (!result.Success)
                return BadRequest(result.Message);
            var partnerProfileResource = _mapper.Map<PartnerProfile, PartnerProfileResource>(result.Resource);
            return Ok(partnerProfileResource);
        }
        /// <summary>
        /// remove a partner profile from the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _partnerProfileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var partnerProfileResource = _mapper.Map<PartnerProfile, PartnerProfileResource>(result.Resource);
            return Ok(partnerProfileResource);
        }
    }
}
