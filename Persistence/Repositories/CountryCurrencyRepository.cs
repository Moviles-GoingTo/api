using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories.Geographic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Persistence.Repositories
{
    public class CountryCurrencyRepository : BaseRepository, ICountryCurrencyRepository
    {
        public CountryCurrencyRepository(AppDbContext context) : base(context){}

        public async Task AddAsync(CountryCurrency countryCurrency)
        {
            await _context.CountryCurrencies.AddAsync(countryCurrency);
        }

        public async Task AssignCountryCurrency(int countryId, int currencyId)
        {
            CountryCurrency countryCurrency = await FindByCountryIdAndCurrencyId(countryId, currencyId);
            if(countryCurrency == null)
            {
                countryCurrency = new CountryCurrency { CountryId = countryId, CurrencyId = currencyId };
                await AddAsync(countryCurrency);
            }
        }

        public async Task<CountryCurrency> FindByCountryIdAndCurrencyId(int countryId, int currencyId)
        {
            return await _context.CountryCurrencies.FindAsync(countryId, currencyId);
        }

        public async Task<IEnumerable<CountryCurrency>> ListAsync()
        {
            return await _context.CountryCurrencies
                .Include(cc => cc.Country)
                .Include(cc => cc.Currency)
                .ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCountryAsync(int countryId)
        {
            return await _context.CountryCurrencies
                .Where(cc => cc.CountryId == countryId)
                .Include(cc => cc.Country)
                .Include(cc => cc.Currency)
                .ToListAsync();
        }

        public async Task<IEnumerable<CountryCurrency>> ListByCurrencyAsync(int currencyId)
        {
            return await _context.CountryCurrencies
               .Where(cc => cc.CurrencyId == currencyId)
               .Include(cc => cc.Country)
               .Include(cc => cc.Currency)
               .ToListAsync();
        }

        public void Remove(CountryCurrency countryCurrency)
        {
            _context.CountryCurrencies.Remove(countryCurrency);
        }

        public async void UnassignCountryCurrency(int countryId, int currencyId)
        {
            CountryCurrency countryCurrency = await FindByCountryIdAndCurrencyId(countryId, currencyId);
            if (countryCurrency == null)
                Remove(countryCurrency);
        }
    }
}
