using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using GoingTo_API.Resources.SaveResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records.NotUsed;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route ("/api/partners")]
    public class PartnersController : Controller
    {
        private readonly IPartnerService _partnerService;
        private readonly IMapper _mapper;

        public PartnersController(IPartnerService partnerService, IMapper mapper)
        {
            _partnerService = partnerService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the partners in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PartnerResource>> GetAllAsync()
        {
            var partners = await _partnerService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Partner>,IEnumerable<PartnerResource>> (partners);

            return resource;
        }

        /// <summary>
        /// creates a partner in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePartnerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var partner = _mapper.Map<SavePartnerResource, Partner>(resource);
            var result = await _partnerService.SaveAsync(partner);

            if (!result.Success)
                return BadRequest(result.Message);

            var partnerResource = _mapper.Map<Partner, PartnerResource>(result.Resource);
            return Ok(partnerResource);
        }

        /// <summary>
        /// modify a partner in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePartnerResource resource )
        {
            var partner = _mapper.Map<SavePartnerResource, Partner>(resource);
            var result = await _partnerService.UpdateAsync(id, partner);

            if (!result.Success)
                return BadRequest(result.Message);

            var partnerResource = _mapper.Map<Partner, PartnerResource>(result.Resource);
            return Ok(partnerResource);
        }
        /// <summary>
        /// remove a partner in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await  _partnerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var partnerResource = _mapper.Map<Partner, PartnerResource>(result.Resource);
            return Ok(partnerResource);
        }
    }
}
