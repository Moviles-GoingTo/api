using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class PlacesController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public PlacesController(IPlaceService placeService, IMapper mapper)
        {
            _mapper = mapper;
            _placeService = placeService;
        }
        /// <summary>
        /// returns al the places in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlaceResource>> GetAllAsync()
        {
            var places = await _placeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceResource>>(places);
            return resources;
        }

        /// <summary>
        /// creates a place in the system
        /// </summary>
        /// <param name="resource">a place resource</param>
        /// <response code="201">creates a place in the system</response>
        /// <response code="400">unable to create the place due validation</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePlaceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var place = _mapper.Map<SavePlaceResource, Place>(resource);
            var result = await _placeService.SaveAsync(place);

            if (!result.Success)
                return BadRequest(result.Message);

            var placeResource = _mapper.Map<Place, PlaceResource>(result.Resource);
            return Ok(placeResource);
        }
        /// <summary>
        /// returns one place  by id
        /// </summary>
        /// <param name="name" example="Machu Picchu">the place Id</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _placeService.GetByNameAsync(name);
            if (!result.Success)
                return BadRequest(result.Message);
            var placeResource = _mapper.Map<Place, PlaceResource>(result.Resource);
            return Ok(placeResource);
        }
        /// <summary>
        /// allows to change the name of a place
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]SavePlaceResource resource)
        {
            var place = _mapper.Map<SavePlaceResource, Place>(resource);
            var result = await _placeService.UpdateAsync(id, place);

            if (!result.Success)
                return BadRequest(result.Message);
            var placeResource = _mapper.Map<Place, PlaceResource>(result.Resource);
            return Ok(placeResource);
        }
    }
}
