using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IBenefitRepository
    {
        Task<IEnumerable<Benefit>> ListAsync();
        Task AddAsync(Benefit benefit);
        Task<Benefit> FindById(int id);
        void Update(Benefit benefit);
        void Remove(Benefit benefit);
    }
}
