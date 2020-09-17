using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Geographic;
using GoingTo_API.Resources;
using GoingTo_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/countries/{countryId}/languages")]
    [Produces("application/json")]
    public class CountryLanguagesController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICountryLanguageService _countryLanguageService;
        private readonly ILanguageService _languageService;

        public CountryLanguagesController(ICountryLanguageService countryLanguageService, ILanguageService languageService, IMapper mapper)
        {
            _mapper = mapper;
            _countryLanguageService = countryLanguageService;
            _languageService = languageService;
        }
        /// <summary>
        /// returns all the languages of one country in the system.
        /// </summary>
        /// <param name="countryId">the country id</param>
        /// <response code="200">returns all the languages of one country in the system. </response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<LanguageResource>> GetAllByCountryIdAsync(int countryId)
        {
            var languages = await _languageService.ListByCountryIdAsync(countryId);
            var resources = _mapper.Map<IEnumerable<Language>, IEnumerable<LanguageResource>>(languages);
            return resources;
        }
        /// <summary>
        /// assign a language to a country
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="languageId"></param>
        /// <response code="204">the language was asigned successfully</response>
        /// <returns></returns>
        [HttpPut("{languageId}")]
        public async Task<IActionResult> AssignCountryLanguage(int countryId, int languageId)
        {

            var result = await _countryLanguageService.AssignCountryLanguageAsync(countryId, languageId);
            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource.Language);
            return Ok(languageResource);

        }
        /// <summary>
        /// delete a language from one country
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="languageId"></param>
        /// <response code="204">the language was unasigned successfully</response>
        /// <returns></returns>
        [HttpDelete("languageId")]
        public async Task<IActionResult> UnasignCountryLanguage(int countryId, int languageId)
        {
            var result = await _countryLanguageService.UnassignCountryLanguageAsync(countryId, languageId);
            if (!result.Success)
                return BadRequest(result.Message);
            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource.Language);
            return Ok(languageResource);
        }
    }
}
