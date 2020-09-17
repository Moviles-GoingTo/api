using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class CountryResponse : BaseResponse<Country>
    {
        public CountryResponse(string message) : base(message) { }
        public CountryResponse(Country country) : base(country) { }
    }
}
