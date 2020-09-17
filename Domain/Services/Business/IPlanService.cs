using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<IEnumerable<Plan>> ListByUserIdAsync(int userId);
        Task<PlanResponse> GetByIdAsync(int id);
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> UpdateAsync(int id,Plan plan);
        Task<PlanResponse> DeleteAsync(int id);

    }
}
