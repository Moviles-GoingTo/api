using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Route("/api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService _profileService;
        private readonly AutoMapper.IMapper _mapper;

        public UserProfilesController(IUserProfileService profileService, AutoMapper.IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }


        /// <summary>
        /// returns all the profiles in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resource = _mapper.Map<IEnumerable<GoingTo_API.Domain.Models.Accounts.UserProfile>, IEnumerable<UserProfileResource>>(profiles);
            return resource;
        }


        /// <summary>
        /// add a profile in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages()); 
            var profile = _mapper.Map<SaveProfileResource, GoingTo_API.Domain.Models.Accounts.UserProfile>(resource);
            var result = await _profileService.SaveAsync(profile); 

            if (!result.Success)
                return BadRequest(result.Message); 

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Accounts.UserProfile, UserProfileResource>(result.Profile); 
            return Ok(profileResource);
        }


        /// <summary>
        /// modify a profile in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
        {
            var profile = _mapper.Map<SaveProfileResource, GoingTo_API.Domain.Models.Accounts.UserProfile>(resource);
            var result = await _profileService.UpdateAsync(id, profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Accounts.UserProfile, UserProfileResource>(result.Profile);
            return Ok(profileResource);
        }


        /// <summary>
        /// remove a profile in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<GoingTo_API.Domain.Models.Accounts.UserProfile, UserProfileResource>(result.Profile);
            return Ok(profileResource);
        }
    }
}
