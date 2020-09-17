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
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryServices;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryServices, IMapper mapper)
        {
            _countryServices = countryServices;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the countries in the system
        /// </summary>
        /// <response code="200">returns all the countries in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var countries = await _countryServices.ListAsync();
            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);
            return resources;
        }
        /// <summary>
        /// returns a country by searching name
        /// </summary>
        /// <param name="name" example="PeRu">the country id</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByIdAsync(string name)
        {
            var result = await _countryServices.GetByFullNameAsync(name);
            if (!result.Success)
                return BadRequest(result.Message);
            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }
    }
}
