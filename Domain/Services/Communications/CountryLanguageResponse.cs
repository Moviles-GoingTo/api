using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class CountryLanguageResponse : BaseResponse<CountryLanguage>
    {
        public CountryLanguageResponse(CountryLanguage CountryLanguage) : base(CountryLanguage) { }

        public CountryLanguageResponse(string message) : base(message) { }
    }
}
