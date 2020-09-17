using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services.Business
{
    public interface ILocatablePromoService
    {
        Task<IEnumerable<LocatablePromo>> ListAsync();
        Task<IEnumerable<LocatablePromo>> ListByLocatableIdAsync(int locatableId);
        Task<IEnumerable<LocatablePromo>> ListByPromoIdAsync(int promoId);
        Task<LocatablePromoResponse> AssignLocatablePromoAsync(int locatableId, int promoId);
        Task<LocatablePromoResponse> UnassignLocatablePromoAsync(int locatableId, int promoId);
    }
}
