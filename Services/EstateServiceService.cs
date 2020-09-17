using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class EstateServiceService : IEstateServiceService
    {
        private readonly IEstateServiceRepository _estateServiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EstateServiceService(IEstateServiceRepository estateServiceRepository, IUnitOfWork unitOfWork)
        {
            _estateServiceRepository = estateServiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EstateServiceResponse> AssignEstateServiceAsync(int estateId, int serviceId)
        {
            try
            {
                await _estateServiceRepository.AssignEstateService(estateId, serviceId);
                await _unitOfWork.CompleteAsync();
                Domain.Models.Interactions.EstateService estateService = await _estateServiceRepository.FindByEstateIdAndServiceId(estateId, serviceId);

                return new EstateServiceResponse(estateService);
            }
            catch(Exception ex)
            {
                return new EstateServiceResponse($"An error ocurred while assigning Service to Estate: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Domain.Models.Interactions.EstateService>> ListAsync()
        {
            return await _estateServiceRepository.ListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Interactions.EstateService>> ListByEstateIdAsync(int estateId)
        {
            return await _estateServiceRepository.ListByEstateId(estateId);
        }

        public async Task<IEnumerable<Domain.Models.Interactions.EstateService>> ListByServiceIdAsync(int serviceId)
        {
            return await _estateServiceRepository.ListByServiceId(serviceId);
        }

        public async Task<EstateServiceResponse> UnassignEstateServiceAsync(int estateId, int serviceId)
        {
            try
            {
                Domain.Models.Interactions.EstateService estateService = await _estateServiceRepository.FindByEstateIdAndServiceId(estateId, serviceId);
                _estateServiceRepository.Remove(estateService);
                await _unitOfWork.CompleteAsync();

                return new EstateServiceResponse(estateService);
            }
            catch (Exception ex)
            {
                return new EstateServiceResponse($"An error ocurred while assigning Service to Estate: {ex.Message}");
            }
        }
    }
}
