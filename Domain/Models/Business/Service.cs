using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EstateService> EstateServices { get; set; }
    }
}
