using GoingTo_API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class LanguageResponse : BaseResponse<Language>
    {
        public LanguageResponse(string message) : base(message) { }
        public LanguageResponse(Language language) : base(language) { }
    }
}
