using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Communications;
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
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class AchievementsController: Controller
    {
        private readonly IAchievementService _achievementService;
        private readonly IMapper _mapper;

        public AchievementsController(IAchievementService achievementService, IMapper mapper)
        {
            _achievementService = achievementService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the achievements in the system.
        /// </summary>
        /// <response code="200">returns all the achievements in the system.</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AchievementResource>> GetAllAsync()
        {
            var achievements = await _achievementService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Achievement>, IEnumerable<AchievementResource>>(achievements);
            return resources;
        }

        /// <summary>
        /// creates an achievements in the system.
        /// </summary>
        /// <response code="201">creates an achievements in the system.</response>
        /// <response code="400">unable to create the achievement due to validation.</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAchievementResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var achievement = _mapper.Map<SaveAchievementResource, Achievement>(resource);
            var result = await _achievementService.SaveAsync(achievement);

            if (!result.Success)
                return BadRequest(result.Message);

            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource);
            return Ok(achievementResource);
        }
        /// <summary>
        /// allows to change the Name,Text and/or Points of an existing achievement
        /// </summary>
        /// <param name="id">the id of the achievement to update</param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveAchievementResource resource)
        {
            var achievement = _mapper.Map<SaveAchievementResource, Achievement>(resource);
            var result = await _achievementService.UpdateAsync(id, achievement);

            if (!result.Success)
                return BadRequest(result.Message);
            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource);
            return Ok(achievementResource);
        }

    }
}
