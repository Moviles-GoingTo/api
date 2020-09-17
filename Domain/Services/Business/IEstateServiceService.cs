using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Business
{
    public interface IEstateServiceService
    {
        Task<IEnumerable<EstateService>> ListAsync();
        Task<IEnumerable<EstateService>> ListByEstateIdAsync(int estateId);
        Task<IEnumerable<EstateService>> ListByServiceIdAsync(int serviceId);
        Task<EstateServiceResponse> AssignEstateServiceAsync(int estateId, int serviceId);
        Task<EstateServiceResponse> UnassignEstateServiceAsync(int estateId, int serviceId);
    }
}
