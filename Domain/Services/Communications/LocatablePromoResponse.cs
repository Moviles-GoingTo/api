using System;
using GoingTo_API.Domain.Models.Business;

namespace GoingTo_API.Domain.Services.Communications
{
    public class LocatablePromoResponse : BaseResponse<LocatablePromo> 
    {
        public LocatablePromoResponse(LocatablePromo locatablePromo) : base(locatablePromo)
        {
        }
        public LocatablePromoResponse(string message) : base(message)
        {
        }

    }
}
