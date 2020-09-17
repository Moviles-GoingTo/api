using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class EstateServiceResource
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int EstateId { get; set; }
        public string Text { get; set; }
    }
}
