using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Accounts
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> ListAsync();
        Task AddAsync(Partner partner);
        Task<Partner> FindById(int id);
        void Update(Partner partner);
        void Remove(Partner partner);
    }
}
