using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IPartnerProfileService
    {
        Task<PartnerProfileResponse> SaveAsync(PartnerProfile partnerProfile);
        Task<PartnerProfileResponse> DeleteAsync(int id);
        Task<PartnerProfileResponse> GetByPartnerIdAsync(int partnerId);
        Task<PartnerProfileResponse> UpdateAsync(int id, PartnerProfile partnerProfile);

    }
}
