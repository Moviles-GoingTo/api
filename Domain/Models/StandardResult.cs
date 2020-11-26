using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class StandardResult<T>
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public string Status { get; set; }
        public T Result { get; set; }

        public StandardResult(T result, string message, int code, string status)        
        {
            Result = result;
            Message = message;
            Code = code;
            Status = status;
        }
    }
}
