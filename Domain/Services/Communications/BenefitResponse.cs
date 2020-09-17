using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class BenefitResponse : BaseResponse<Benefit>
    {
        public BenefitResponse(Benefit resource) : base(resource)
        {
        }

        public BenefitResponse(string message) : base(message)
        {
        }
    }
}
