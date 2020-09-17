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
    [Route("/api/[controller]")]
    public class EstatesController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public EstatesController(IEstateService estateService, IMapper mapper)
        {
            _estateService = estateService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the Estates in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EstateResource>> GetAllAsync()
        {
            var estates = await _estateService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Estate>, IEnumerable<EstateResource>>(estates);

            return resource;
        }

        /// <summary>
        /// returns all the Estates by partner name.
        /// </summary>
        /// <param name="partnerName" example=""></param>
        /// <returns></returns>
        [HttpGet("{partnerName}")]
        public async Task<IEnumerable<EstateResource>>ListAllByPartnerName(string partnerName)
        {
            var estates = await _estateService.ListByPartnerNameAsync(partnerName);
            var resource = _mapper.Map<IEnumerable<Estate>, IEnumerable<EstateResource>>(estates);

            return resource;
        }
        /// <summary>
        /// creates an Estate in the system.
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="locatableId"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("{partnerId},{locatableId}")]
        public async Task<IActionResult>PostAsync(int partnerId, int locatableId,[FromBody] SaveEstateResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var estate = _mapper.Map<SaveEstateResource, Estate>(resource);
            estate.LocatableId = locatableId;
            estate.PartnerId = partnerId;

            var result = await _estateService.SaveAsync(estate);

            if (!result.Success)
                return BadRequest(result.Message);

            var estateResource = _mapper.Map<Estate, EstateResource>(result.Resource);
            return Ok(estateResource);
        }
        /// <summary>
        /// modify an Estate in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SaveEstateResource resource)
        {
            var estate = _mapper.Map<SaveEstateResource, Estate>(resource);
            var result = await _estateService.UpdateAsync(id, estate);

            if (!result.Success)
                return BadRequest(result.Message);

            var estateResource = _mapper.Map<Estate, EstateResource>(result.Resource);
            return Ok(estateResource);
        }
        /// <summary>
        /// remove an Estate in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _estateService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var estateResource = _mapper.Map<Estate, EstateResource>(result.Resource);
            return Ok(estateResource);
        }


    }
}
