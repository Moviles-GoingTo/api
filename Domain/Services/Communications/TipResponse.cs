using System;
using GoingTo_API.Domain.Models;

namespace GoingTo_API.Domain.Services.Communications
{
    public class TipResponse : BaseResponse<Tip>
    {
        public TipResponse(Tip tip) : base(tip)
        {
        }
        public TipResponse(string message) : base(message)
        {
        }
    }
}
