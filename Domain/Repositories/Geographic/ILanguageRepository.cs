using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> ListAsync();
        Task AddAsync(Language language);
        Task<Language> FindById(int id);
        void Update(Language language);
    }
}
