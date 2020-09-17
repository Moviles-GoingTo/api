using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Geographic;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    
    [Route("/api/countries/{countryId}/currencies")]
    public class CountryCurrenciesController : Controller
    {
        private readonly ICountryCurrencyService _countryCurrencyService;
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CountryCurrenciesController(ICountryCurrencyService countryCurrencyService, ICurrencyService currencyService, IMapper mapper)
        {
            _countryCurrencyService = countryCurrencyService;
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CurrencyResource>> GetAllByCountryIdAsync(int countryId)
        {
            var currencies = await _currencyService.ListByCountryIdAsync(countryId);
            var resources = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);

            return resources;
        }

        /// <summary>
        /// assign a currency to a country
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="currencyId"></param>
        /// <response code="204">the currency was asigned successfully</response>
        /// <returns></returns>
        [HttpPut("{currencyId}")]
        public async Task<IActionResult> AssignCountryCurrency(int countryId, int currencyId)
        {
            var result = await _countryCurrencyService.AssignCountryCurrencyAsync(countryId, currencyId);
            if (!result.Success)
                return BadRequest(result.Message);

            var currencyResource = _mapper.Map<Currency, CurrencyResource>(result.Resource.Currency);
            return Ok(currencyResource);
        }
        /// <summary>
        /// unassign a currency to a country
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="currencyId"></param>
        /// <returns></returns>
        [HttpDelete("{currencyId}")]
        public async Task<IActionResult> UnassignCountryCurrency(int countryId, int currencyId)
        {
            var result = await _countryCurrencyService.UnassignCountryCurrencyAsync(countryId, currencyId);
            if (!result.Success)
                return BadRequest(result.Message);

            var currencyResource = _mapper.Map<Currency, CurrencyResource>(result.Resource.Currency);
            return Ok(currencyResource);
        }

    }
}
