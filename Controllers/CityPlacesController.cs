using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    
    [Route("/api/cities/{cityId}/places")]
    [Produces("application/json")]
    public class CityPlacesController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public CityPlacesController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the places of one city in the system.
        /// </summary>
        /// <param name="cityId">the city id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlaceResource>> GetAllByCityIdAsync(int cityId)
        {
            var places = await _placeService.ListByCityIdAsync(cityId);
            var resources = _mapper.Map<IEnumerable<Place>, IEnumerable<PlaceResource>>(places);
            return resources;
        }
    }
}
