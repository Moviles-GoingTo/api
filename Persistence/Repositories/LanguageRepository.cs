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
    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
        public LanguageRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Language language)
        {
            await _context.Languages.AddAsync(language);
        }

        public async Task<Language> FindById(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task<IEnumerable<Language>> ListAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public void Update(Language language)
        {
            _context.Languages.Update(language);
        }
    }
}
