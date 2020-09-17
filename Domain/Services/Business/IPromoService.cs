using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IPromoService 
    {
        Task<IEnumerable<Promo>> ListAsync();
        Task<PromoResponse> SaveAsync(Promo promo);
        Task<PromoResponse> UpdateAsync(int id, Promo promo);
        Task<PromoResponse> DeleteAsync(int id);
        Task<PromoResponse> GetByIdAsync(int id);
        Task<IEnumerable<Promo>> ListPromoByPartnerId(int partnerId);
        Task<IEnumerable<Promo>> ListByLocatableId(int locatableId);
    }
}
