using GoingTo_API.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Interactions
{
    public class EstateService
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Service Service { get; set; }
        public int ServiceId { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
