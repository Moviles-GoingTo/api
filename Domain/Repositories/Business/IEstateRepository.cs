using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IEstateRepository
    {
        Task<IEnumerable<Estate>> ListAsync();
        Task<IEnumerable<Estate>> ListByPartnerNameAsync(string partnerName);
        Task AddAsync(Estate estate);
        Task<Estate> FindById(int id);
        void Update(Estate estate);
        void Remove(Estate estate);
    }
}
