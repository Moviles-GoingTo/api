using GoingTo_API.Resources;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.SwaggerExamples.Request
{
    public class SavePlaceResourceExample : IExamplesProvider<SavePlaceResource>
    {
        public SavePlaceResource GetExamples()
        {
            return new SavePlaceResource
            {
                CityId = 1,
                LocatableId = 22,
                Name = "A new place resource"
            };

        }
    }
}
