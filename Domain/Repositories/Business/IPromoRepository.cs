using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IPromoRepository
    {
        Task<IEnumerable<Promo>> ListAsync();
        Task<IEnumerable<Promo>> FindByPartnerId(int partnerId);
        Task AddAsync(Promo promo);
        Task<Promo> FindById(int id);
        void Update(Promo promo);
        void Remove(Promo promo);
    }
}
