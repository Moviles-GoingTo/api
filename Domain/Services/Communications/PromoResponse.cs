using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PromoResponse : BaseResponse<Promo>
    {
        public PromoResponse(Promo resource) : base(resource)
        {
        }

        public PromoResponse(string message) : base(message)
        {
        }
    }
}
