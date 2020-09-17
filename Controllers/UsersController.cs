using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

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

            if (response == null)
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _userService.SaveAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        /// <summary>
        /// modify an user in the system
        /// </summary>
        /// <param name="id"></param>
        /// <param name="resource"></param>
        /// <returns></returns>

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
