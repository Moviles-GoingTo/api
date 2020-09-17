using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
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
    [Route("/api/users/{userId}/locatables")]
    [Produces("application/json")]
    public class FavouritesController : Controller
    {
        private readonly ILocatableService _locatableService;
        private readonly IFavouriteService _favouriteService;
        private readonly IMapper _mapper;

        public FavouritesController(ILocatableService locatableService, IFavouriteService favouriteService, IMapper mapper)
        {
            _locatableService = locatableService;
            _favouriteService = favouriteService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the favourites locatables of one user in the system.
        /// </summary>
        /// <param name="userId">the user id</param>
        /// <response code="200">returns all the favourites locatables of one user in the system. </response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<LocatableResource>> GetAllByUserIdAsync(int userId)
        {
            var locatables = await _locatableService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Locatable>, IEnumerable<LocatableResource>>(locatables);
            return resources;
        }
        /// <summary>
        /// add a locatable to the user's favorites collection.
        /// </summary>
        /// <param name="userId"  example="1"></param>
        /// <param name="locatableId"  example="1"></param>
        /// <returns></returns>
        [HttpPost("{locatableId}")]
        public async Task<IActionResult> AssignFavourite(int userId, int locatableId)
        {
            var result = await _favouriteService.AssignFavouriteAsync(userId, locatableId);
            if (!result.Success)
                return BadRequest(result.Message);
            var locatableResource = _mapper.Map<Locatable, LocatableResource>(result.Resource.Locatable);
            return Ok(locatableResource);
        }
        /// <summary>
        /// delete a favourite locatable from one user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="locatableId"></param>
        /// <response code="204">the favourite locatable was unasigned successfully</response>
        /// <returns></returns>
        [HttpDelete("LocatableId")]
        public async Task<IActionResult> UnassignFavourite(int userId, int locatableId)
        {
            var result = await _favouriteService.UnassignFavouriteAsync(userId, locatableId);
            if (!result.Success)
                return BadRequest(result.Message);
            var locatableResource = _mapper.Map<Locatable, LocatableResource>(result.Resource.Locatable);
            return Ok(locatableResource);
        }
    }
}
