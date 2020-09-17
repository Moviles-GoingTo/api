using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/locatable/{locatableId}/promos")]
    public class LocatablePromosController : Controller
    {
        private readonly IPromoService _promoService;
        private readonly ILocatablePromoService _locatablePromoService;
        private readonly IMapper _mapper;
        public LocatablePromosController(IPromoService promoService, ILocatablePromoService locatablePromoService, IMapper mapper)
        {
            _locatablePromoService = locatablePromoService;
            _promoService = promoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByLocatableId(int locatableId)
        {
            var promos = await _promoService.ListByLocatableId(locatableId);
            if (promos == null)
                return BadRequest(ModelState.GetErrorMessages());
            var resources = _mapper.Map<IEnumerable<Promo>, IEnumerable<PromoResource>>(promos);
            return Ok(resources);
        }

        [HttpPost("{promoId}")]
        public async Task<IActionResult> AssignLocatablePromo(int locatableId,int promoId)
        {
            var result = await _locatablePromoService.AssignLocatablePromoAsync(locatableId, promoId);
            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());
            var locatablePromo = _mapper.Map<Promo, PromoResource>(result.Resource.Promo);
            return Ok(locatablePromo);
        }

        [HttpDelete("{promoId}")]
        public async Task<IActionResult> UnassignLocatblePromo(int locatableId,int promoId)
        {
            var existingPromo = await _promoService.GetByIdAsync(promoId);
            if (existingPromo == null)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _locatablePromoService.UnassignLocatablePromoAsync(locatableId, promoId);
            var resource = _mapper.Map<Promo, PromoResource>(result.Resource.Promo);
            return Ok(resource);
        }
    }
}
