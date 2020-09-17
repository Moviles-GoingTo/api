using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Extensions;
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
    [Route("/api/[Controller]")]
    [Produces("application/json")]
    public class LanguagesController: Controller
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguagesController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the languages in the system
        /// </summary>
        /// <response code="200">returns all the languages in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<LanguageResource>> GetAllAsync()
        {
            var categories = await _languageService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Language>, IEnumerable<LanguageResource>>(categories);
            return resources;
        }
        /// <summary>
        /// returns one language by id
        /// </summary>
        /// <param name="id" example="1">the language id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _languageService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource);
            return Ok(languageResource);

        }
        /// <summary>
        /// creates a language in the system.
        /// </summary>
        /// <response code="201">creates a language in the system.</response>
        /// <response code="400">unable to create the language due to validation.</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveLanguageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var language = _mapper.Map<SaveLanguageResource, Language>(resource);
            var result = await _languageService.SaveAsync(language);

            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource);
            return Ok(languageResource);
        }
        /// <summary>
        /// allows to change the ShortName and/or FullName of an existing Language
        /// </summary>
        /// <param name="id">the id of the language to update</param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLanguageResource resource)
        {
            var language = _mapper.Map<SaveLanguageResource, Language>(resource);
            var result = await _languageService.UpdateAsync(id, language);

            if (!result.Success)
                return BadRequest(result.Message);
            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource);
            return Ok(languageResource);
        }
        
    }
}
