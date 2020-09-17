using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PartnerResponse : BaseResponse<Partner>
    {
        public PartnerResponse(Partner resource) : base(resource){}
        public PartnerResponse(string message) : base(message){}
    }
}
