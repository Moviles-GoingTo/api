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
    
    [Route("/api/countries/{countryId}/cities")]
    [Produces("application/json")]
    public class CountryCitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CountryCitiesController(ICityService cityService, IMapper mapper)
        {
            _mapper = mapper;
            _cityService = cityService;
        }
        /// <summary>
        /// returns all the cities in one country
        /// </summary>
        /// <param name="countryId" example = "1">country Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllByCountryIdAsync(int countryId)
        {
            var cities = await _cityService.ListByCountryIdAsync(countryId);
            var resources = _mapper.Map<IEnumerable<City>,IEnumerable< CityResource >> (cities);
            return resources;
        }

    }
}
