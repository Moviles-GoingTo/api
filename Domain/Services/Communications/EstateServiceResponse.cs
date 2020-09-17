using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class EstateServiceResponse : BaseResponse<EstateService>
    {
        public EstateServiceResponse(EstateService resource) : base(resource)
        {
        }

        public EstateServiceResponse(string message) : base(message)
        {
        }
    }
}
