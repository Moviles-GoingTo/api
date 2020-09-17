using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    
    [Route("/api/[Controller]")]
    [Produces("application/json")]
    public class CitiesController : Controller
    {
        private readonly ICityService _cityServices;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityServices, IMapper mapper)
        {
            _cityServices = cityServices;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the cities in the system
        /// </summary>
        /// <response code="200">returns all the cities in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAllAsync()
        {
            var cities = await _cityServices.ListAsync();
            var resources = _mapper.Map<IEnumerable<City>, IEnumerable<CityResource>>(cities);
            return resources;
        }
        /// <summary>
        /// returns one city by name
        /// </summary>
        /// <param name="name" example="CuSco">the city name</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult> GetAsync(string name)
        {
            var result = await _cityServices.GetByNameAsync(name);
            if (!result.Success)
                return BadRequest(result.Message);
            var cityResource = _mapper.Map<City, CityResource>(result.Resource);
            return Ok(cityResource);
        }
    }
}
