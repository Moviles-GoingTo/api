using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface ILocatablePromoRepository
    {
        Task<IEnumerable<LocatablePromo>> ListAsync();
        Task<IEnumerable<LocatablePromo>> ListByLocatableIdAsync(int locatableId);
        Task<IEnumerable<LocatablePromo>> ListByPromoIdAsync(int promoId);
        Task<LocatablePromo> FindByLocatableIdAndPromoId(int locatableId, int promoId);
        Task AddAsync(LocatablePromo locatablePromo);
        void Remove(LocatablePromo locatablePromo);
        Task AssignLocatablePromo(int locatableId, int promoId);
        void UnassignLocatablePromoAsync(int locatableId, int promoId);
        
    }
}
