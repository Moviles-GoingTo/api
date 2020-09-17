using GoingTo_API.Domain.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class PlaceCategoryResponse : BaseResponse<PlaceCategory>
    {
        public PlaceCategoryResponse(PlaceCategory placeCategory) : base(placeCategory)
        {
        }

        public PlaceCategoryResponse(string message) : base(message) { }
    }
}
