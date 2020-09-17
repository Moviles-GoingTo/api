using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IBenefitService
    {
        Task<IEnumerable<Benefit>> ListAsync();
        Task<BenefitResponse> SaveAsync(Benefit benefit);
        Task<BenefitResponse> UpdateAsync(int id, Benefit benefit);
        Task<BenefitResponse> DeleteAsync(int id);
        Task<BenefitResponse> GetByIdAsync(int id);
    }
}
