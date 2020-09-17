using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;

namespace GoingTo_API.Domain.Repositories.Business
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> ListAsync();
        Task<Service> FindById(int serviceId);
        Task AddAsync(Service service);
        void Update(Service service);
        void Remove(Service service);
    }
}
