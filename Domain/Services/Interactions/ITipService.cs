using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Domain.Services.Geographic
{
    public interface ITipService
    {
        Task<IEnumerable<Tip>> ListByLocatableIdAsync(int locatableId);

        Task<TipResponse> GetByIdAsync(int tipId);

        Task<TipResponse> SaveAsync(Tip tip);

        Task<TipResponse> UpdateAsync(int tipId, Tip tip);

        Task<TipResponse> DeleteAsync(int tipId);
    }
}
