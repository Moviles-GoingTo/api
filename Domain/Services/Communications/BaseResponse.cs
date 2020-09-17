using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Communications
{
    public class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public T Resource { get; protected set; }
        public BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;  
        }
    }
}
