using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Resources;
using GoingTo_API.Services;
using GoingTo_API.Domain.Models.Accounts;
using Microsoft.AspNetCore.Authorization;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/users/{userId}/achievements")]
    [Produces("application/json")]
    public class UserAchievementController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserAchievementService _userAchievementService;
        private readonly IAchievementService _achievementService;

        public UserAchievementController(IAchievementService achievementService ,IUserAchievementService userAchievementService, IMapper mapper)
        {
            _achievementService = achievementService; 
            _mapper = mapper;
            _userAchievementService = userAchievementService;
        }
        /// <summary>
        /// returns all the achievements of an user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AchievementResource>> GetAllByUserIdAsync(int userId)
        {
            var achievements = await _achievementService.ListByUserIdAsync(userId);
            var resources = _mapper
                .Map<IEnumerable<Achievement>, IEnumerable<AchievementResource>>(achievements);
            return resources;
        }

        /// <summary>
        /// assign an achievement to an users
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="achievementId"></param>
        /// <returns></returns>
        [HttpPost("{achievementId}")]
        public async Task<IActionResult> AssignUserAchievement(int userId, int achievementId)
        {

            var result = await _userAchievementService.AssignUserAchievementAsync(userId, achievementId);
            if (!result.Success)
                return BadRequest(result.Message);
            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource.Achievement);
            return Ok(achievementResource);

        }
        /// <summary>
        /// delete an achivement from one user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="achievementId"></param>
        /// <response code="204">the achievement was unasigned successfully</response>
        /// <returns></returns>
        [HttpDelete("achievementId")]
        public async Task<IActionResult> UnassignUserAchievement(int userId, int achievementId)
        {
            var result = await _userAchievementService.UnassignUserAchievementAsync(userId, achievementId);
            if (!result.Success)
                return BadRequest(result.Message);
            var achievementResource = _mapper.Map<Achievement, AchievementResource>(result.Resource.Achievement);
            return Ok(achievementResource);
        }

    }
}