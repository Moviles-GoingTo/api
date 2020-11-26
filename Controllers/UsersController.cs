using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Renci.SshNet.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IUserProfileService userProfileService, IMapper mapper)
        {
            _userService = userService;
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the users on the system.
        /// </summary>
        /// <returns></returns> 
        

        /// <summary>
        /// returns all the users on the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var users = await _userService.ListAsync();
            var resource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return resource;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);

            if (response.Result == null)
                return BadRequest(new { message = "Invalid Email or Password." });

            return Ok(response.Result);
        }

       
        /// <summary>
        /// add an user in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            StandardResult<UserResource> standardResult = null;
            if (!ModelState.IsValid)
            {
                standardResult = new StandardResult<UserResource>(null, ModelState.GetErrorMessages().ToString(), 500, "Error");
                return BadRequest(standardResult);
            }

            var user = _mapper.Map<SaveUserResource, User>(resource);
            var userProfile = _mapper.Map<SaveUserResource, UserProfile>(resource); 

            var resultUser = await _userService.SaveAsync(user);
            userProfile.UserId = resultUser.Resource.Id;
            var resultUserProfile = await _userProfileService.SaveAsync(userProfile);

            if (!resultUser.Success && !resultUserProfile.Success)
            {
                standardResult = new StandardResult<UserResource>(null, resultUser.Message + "\n" + resultUserProfile.Message, 500, "Error");
                return BadRequest(standardResult);
            }

            if (!resultUser.Success)
            {
                standardResult = new StandardResult<UserResource>(null, resultUser.Message, 500, "Error");
                return BadRequest(standardResult);
            }

            if (!resultUserProfile.Success)
            {
                standardResult = new StandardResult<UserResource>(null, resultUserProfile.Message, 500, "Error");
                return BadRequest(standardResult);
            }

            var userResource = _mapper.Map<User, UserResource>(resultUser.Resource);
            standardResult = new StandardResult<UserResource>(userResource, "Usuario ingresado", 200, "OK");
            return Ok(standardResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        /// <summary>
        /// remove an user in the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

    }
}
