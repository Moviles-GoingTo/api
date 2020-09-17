using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IEstateService
    {
        Task<IEnumerable<Estate>> ListAsync();
        Task<IEnumerable<Estate>> ListByPartnerNameAsync(string partnerName);
        Task<EstateResponse> SaveAsync(Estate estate);
        Task<EstateResponse> UpdateAsync(int id, Estate estate);
        Task<EstateResponse> DeleteAsync(int id);
        Task<EstateResponse> GetByIdAsync(int id);
    }
}
