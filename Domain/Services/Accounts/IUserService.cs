using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Services.Communications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Accounts
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
        Task<UserResponse> GetByIdAsync(int id);

        
    }
}
