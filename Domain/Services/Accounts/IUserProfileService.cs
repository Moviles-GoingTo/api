using GoingTo_API.Domain.Models.Accounts;
using System.Collections.Generic;
using GoingTo_API.Domain.Services.Communications;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Accounts
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> ListAsync();
        Task<ProfileResponse> FindById(int userProfileId);
        Task<ProfileResponse> SaveAsync(UserProfile profile);
        Task<ProfileResponse> UpdateAsync(int id, UserProfile profile);
        Task<ProfileResponse> DeleteAsync(int id);
    }
}
