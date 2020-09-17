using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Geographic;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/locatables/{locatableId}/tips")]
    [Produces("application/json")]
    public class LocatableTipsController : Controller
    {
        private readonly ILocatableService _locatableService;
        private readonly ITipService _tipService;
        private readonly IMapper _mapper;

        public LocatableTipsController(ILocatableService locatableService,ITipService tipService,IMapper mapper)
        {
            _locatableService = locatableService;
            _tipService = tipService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all tips of a locatable in the system
        /// </summary>
        /// <response code="200">returns all tips of a locatable in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTipsByLocatableIdAsync(int locatableId)
        {
            var existingLocatable = await _locatableService.GetByIdAsync(locatableId);
            if (!existingLocatable.Success)
                return BadRequest(existingLocatable.Message);

            var tips = await _tipService.ListByLocatableIdAsync(locatableId);
            var resources = _mapper.Map<IEnumerable<Tip>, IEnumerable<TipResource>>(tips);

            return Ok(resources);
        }
    }
}
