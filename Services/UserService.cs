using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IUserAchievementRepository _userAchievementsRepository;
        public readonly AppSettings _appSettings;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork,IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }
        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch(Exception ex) 
            {
                return new UserResponse($"An error ocurred while saving the user: { ex.Message}");
            }
        }
        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            existingUser.Email = user.Email;
            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch(Exception ex)
            {
                return new UserResponse($"An error ocured while updating the user {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            try 
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch(Exception ex) 
            {
                return new UserResponse($"An error ocurred while deleting user {ex.Message}");
            }
        }
        
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await _userRepository.FindById(id);
            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            IEnumerable<User> _users = await  _userRepository.ListAsync();
            var user = _users.SingleOrDefault(x => x.Email == request.Email && x.Password == request.Password);
            // return null when user not found
            if(user == null) return null;

            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user,token);
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            // Setup Security Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
