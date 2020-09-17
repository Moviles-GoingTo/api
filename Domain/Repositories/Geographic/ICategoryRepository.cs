using GoingTo_API.Domain.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Geographic
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task AddAsync(Category category);
        Task<Category> FindById(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
