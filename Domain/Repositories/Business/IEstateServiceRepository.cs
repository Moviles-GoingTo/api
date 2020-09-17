using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IEstateServiceRepository
    {
        Task<IEnumerable<EstateService>> ListAsync();
        Task<IEnumerable<EstateService>> ListByEstateId(int estateId);
        Task<IEnumerable<EstateService>> ListByServiceId(int serviceId);
        Task<EstateService> FindByEstateIdAndServiceId(int estateId,int serviceId);
        Task AddAsync(EstateService estateService);
        void Remove(EstateService estateService);
        Task AssignEstateService(int estateId, int serviceId);
        void UnassignEstateService(int estateId, int serviceId);

    }
}
