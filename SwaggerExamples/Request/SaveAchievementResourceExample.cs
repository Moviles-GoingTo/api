using GoingTo_API.Resources;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.SwaggerExamples.Request
{
    public class SaveAchievementResourceExample : IExamplesProvider<SaveAchievementResource>
    {
        public SaveAchievementResource GetExamples()
        {
            return new SaveAchievementResource
            { 
                Name = "Que bien programo, soy feliz!",
                Text = "Hope that you enjoy our API, Mr's Angel",
                Points = 20
               
            };

        }
    }
}
