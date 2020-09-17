using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Repositories.Interactions;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;

namespace GoingTo_API.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService( IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse> DeleteAsync(int serviceId)
        {
            var existingService = await _serviceRepository.FindById(serviceId);
            if (existingService == null)
                return new ServiceResponse("Service not found");

            try
            {
                _serviceRepository.Remove(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch(Exception ex)
            {
                return new ServiceResponse($"An error ocurred while deleting Service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> GetByIdAsync(int serviceId)
        {
            var existingService = await _serviceRepository.FindById(serviceId);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            return new ServiceResponse(existingService);
        }

        public async Task<IEnumerable<Service>> ListAllAsync()
        {
            return await _serviceRepository.ListAsync();
        }
        public async Task<ServiceResponse> SaveAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(service);
            }
            catch(Exception ex)
            {
                return new ServiceResponse($"An error ocurred while saving the Service: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int serviceId, Service service)
        {
            var existingService = await _serviceRepository.FindById(serviceId);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            existingService.Name = service.Name;
            try
            {
                _serviceRepository.Update(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception ex)
            {
                return new ServiceResponse($"An error ocurred while updating service: {ex.Message}");
            }
        }

    }
}
