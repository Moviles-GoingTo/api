using AutoMapper;
using GoingTo_API.Domain.Models.Interactions;
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
    [Route ("/api/estate/{estateId}/services")]
    public class EstateServicesController : Controller
    {
        private readonly IEstateServiceService _estateServiceService;
        private readonly IMapper _mapper;

        public EstateServicesController(IEstateServiceService estateServiceService, IMapper mapper)
        {
            _estateServiceService = estateServiceService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns the Estate Services by EstateId
        /// </summary>
        /// <param name="estateId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EstateServiceResource>> GetAllEstateServicesByEstateId(int estateId)
        {
            var estateServices = await _estateServiceService.ListByEstateIdAsync(estateId);
            var resources = _mapper.Map<IEnumerable<EstateService>, IEnumerable<EstateServiceResource>>(estateServices);

            return resources;
        }
        /// <summary>
        /// assign a Service to a Estate in the system
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpPut("{serviceId}")]
        public async Task<IActionResult> AssignPlanBenefit(int estateId, int serviceId)
        {
            var result = await _estateServiceService.AssignEstateServiceAsync(estateId, serviceId);
            if (!result.Success)
                return BadRequest(result.Message);
            var estateServiceResource = _mapper.Map<EstateService, EstateServiceResource>(result.Resource);
            return Ok(estateServiceResource);
        }

        /// <summary>
        /// unassign a Service to a Estate in the system
        /// </summary>
        /// <param name="estateId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> UnassignPlanBenefit(int estateId, int serviceId)
        {
            var result = await _estateServiceService.UnassignEstateServiceAsync(estateId, serviceId);
            if (!result.Success)
                return BadRequest(result.Message);
            var estateServiceResource = _mapper.Map<EstateService, EstateServiceResource>(result.Resource);
            return Ok(estateServiceResource);
        }
    }
}
