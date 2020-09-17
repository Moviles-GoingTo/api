using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Geographic;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/[controller]")]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CurrenciesController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }
        /// <summary>
        /// return all the currencies on the system
        /// </summary>
        /// <response code="200">returns all the Currencies in the system.</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CurrencyResource>> GetAllAsync()
        {
            var currencies = await _currencyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);
            return resources;
        }
        /// <summary>
        /// return a currency by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _currencyService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var currencyResource = _mapper.Map<Currency, CurrencyResource>(result.Resource);
            return Ok(currencyResource);
                
        }
        /// <summary>
        /// create a currency on the system
        /// </summary>
        /// <param name="resource"></param>
        /// <response code="201">creates a Currency in the system.</response>
        /// <response code="400">unable to create the Currency due to validation.</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCurrencyResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var currency = _mapper.Map<SaveCurrencyResource, Currency>(resource);
            var result = await _currencyService.SaveAsync(currency);

            if (!result.Success)
                return BadRequest(result.Message);

            var currencyResource = _mapper.Map<Currency, CurrencyResource>(result.Resource);
            return Ok(currencyResource);
        }
    }
}
