using GoingTo_API.Domain.Models.Geographic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class CategoryResponse:BaseResponse<Category>
    {
        public CategoryResponse(string message) : base(message) { }

        public CategoryResponse(Category category) : base(category) { }
    }
}
