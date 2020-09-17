using GoingTo_API.Domain.Models.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Accounts
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> ListAsync(); 

        Task AddAsync(UserProfile profile); 

        Task<UserProfile> FindById(int id);
        void Update(UserProfile profile);

        void Remove(UserProfile profile); 
    }
}
