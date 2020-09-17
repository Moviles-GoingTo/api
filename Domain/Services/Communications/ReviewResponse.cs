using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class ReviewResponse : BaseResponse<Review>
    {
        public ReviewResponse(string message) : base(message) { }
        public ReviewResponse(Review review) : base(review) { }
    }
}
