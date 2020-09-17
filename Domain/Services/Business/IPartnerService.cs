using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Accounts
{
    public interface IPartnerService
    {
        Task<IEnumerable<Partner>> ListAsync();
        Task<PartnerResponse> SaveAsync(Partner partner);
        Task<PartnerResponse> UpdateAsync(int id, Partner partner);
        Task<PartnerResponse> DeleteAsync(int id);
        Task<PartnerResponse> GetByIdAsync(int id);
    }
}
