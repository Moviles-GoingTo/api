using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/language/{languageId}/countries")]
    public class LanguageCountriesController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public LanguageCountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the countries by language id
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task <IEnumerable<CountryResource>> GetAllByLanguageId(int languageId)
        {
            var countries = await _countryService.ListByLanguageIdAsync(languageId);
            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);

            return resources;
        }
    }
}
