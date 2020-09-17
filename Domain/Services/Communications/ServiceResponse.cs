using System;
using GoingTo_API.Domain.Models.Business;

namespace GoingTo_API.Domain.Services.Communications
{
    public class ServiceResponse : BaseResponse<Service>
    {
        public ServiceResponse(Service service) :base(service)
        {
        }
        public ServiceResponse(string message) : base(message)
        {
        }
    }
}
