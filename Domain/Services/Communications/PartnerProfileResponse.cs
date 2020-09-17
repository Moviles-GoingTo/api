using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PartnerProfileResponse : BaseResponse<PartnerProfile>
    {
        public PartnerProfileResponse(PartnerProfile resource) : base(resource)
        {
        }

        public PartnerProfileResponse(string message) : base(message)
        {
        }
    }
}
