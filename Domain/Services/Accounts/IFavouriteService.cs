using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services
{
    public interface IFavouriteService 
    {
        Task<IEnumerable<Favourite>> ListAsync();
        Task<IEnumerable<Favourite>> ListByUserIdAsync(int userId);
        Task<FavouriteResponse> AssignFavouriteAsync(int userId, int locatableId);
        Task<FavouriteResponse> UnassignFavouriteAsync(int userId, int locatableId);
    }
}
