using System;
using GoingTo_API.Domain.Models.Interactions;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PartnerServiceResponse : BaseResponse<EstateService>
    {
        public PartnerServiceResponse(EstateService partnerService) : base(partnerService)
        {
        }
        public PartnerServiceResponse(string message) : base(message)
        {
        }
    }
}
