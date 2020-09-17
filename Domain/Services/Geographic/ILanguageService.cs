using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> ListAsync();
        Task<IEnumerable<Language>> ListByCountryIdAsync(int countryId);
        Task<LanguageResponse> GetByIdAsync(int id);
        Task<LanguageResponse> SaveAsync(Language language);
        Task<LanguageResponse> UpdateAsync(int id, Language language);
    }
}
