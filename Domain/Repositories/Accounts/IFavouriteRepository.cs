using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories
{
    public interface IFavouriteRepository
    {
        Task<IEnumerable<Favourite>> ListAsync();
        Task<IEnumerable<Favourite>> ListByUserIdAsync(int userId);
        Task<Favourite> FindByUserIdAndLocatableId(int userId, int locatableId);
        Task AddAsync(Favourite favourite);
        void Remove(Favourite favourite);
        Task AssignFavourite(int userId, int locatableId);
        Task UnassignFavourite(int userId, int locatableId);
    }
}
