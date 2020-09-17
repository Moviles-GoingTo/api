using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class EstateResponse : BaseResponse<Estate>
    {
        public EstateResponse(Estate resource) : base(resource)
        {
        }

        public EstateResponse(string message) : base(message)
        {
        }
    }
}
