using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace GoingTo_API.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
