using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IPartnerProfileRepository
    {
        Task AddAsync(PartnerProfile partnerProfile);
        Task <PartnerProfile> FindById(int id);
        Task<PartnerProfile> FindByPartnerId(int partnerId);
        void Update(PartnerProfile partnerProfile);
        void Remove(PartnerProfile partnerProfile);
    }
}
