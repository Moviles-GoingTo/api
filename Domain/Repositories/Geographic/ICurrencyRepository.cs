using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> ListAsync();
        Task AddAsync(Currency currency);
        Task<Currency> FindById(int id);
        void Update(Currency currency);
        void Remove(Currency currency);
    }
}
