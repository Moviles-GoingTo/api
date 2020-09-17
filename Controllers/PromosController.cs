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
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route ("/api/[controller]")]
    public class PromosController : Controller
    {
        private readonly IPromoService _promoService;
        private readonly IMapper _mapper;

        public PromosController(IPromoService promoService, IMapper mapper)
        {
            _promoService = promoService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the promos in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PromoResource>> GetAllPromos()
        {
            var promos = await _promoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Promo>, IEnumerable<PromoResource>>(promos);

            return resources;
        }

        /// <summary>
        /// returns a promo by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromoId(int id)
        {
            var result = await _promoService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var promoResource = _mapper.Map<Promo, PromoResource>(result.Resource);
            return Ok(promoResource);
        }
        /// <summary>
        /// create a promo in the system.
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("{partnerId}")]
        public async Task<IActionResult> PostAsync(int partnerId ,[FromBody] SavePromoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var promo = _mapper.Map<SavePromoResource, Promo>(resource);
                promo.PartnerId = partnerId;
            var result = await _promoService.SaveAsync(promo);

            if (!result.Success)
                return BadRequest(result.Message);

            var promoResource = _mapper.Map<Promo, PromoResource>(result.Resource);
            return Ok(promoResource);
        }

        /// <summary>
        /// modify a promo in the system.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id,[FromBody] SavePromoResource resource)
        {
            var promo = _mapper.Map<SavePromoResource, Promo>(resource);
            var result = await _promoService.UpdateAsync(id,promo);

            if (!result.Success)
                return BadRequest(result.Message);

            var promoResource = _mapper.Map<Promo, PromoResource>(result.Resource);
            return Ok(promoResource);
        }
        /// <summary>
        /// delete a promo from the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _promoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var promoResource = _mapper.Map<Promo, PromoResource>(result.Resource);
            return Ok(promoResource);
        }

    }
}
