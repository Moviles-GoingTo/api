using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Estate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public int PartnerId { get; set; }
        public Partner Partner { get; set; } 
        public List<EstateService> EstateServices { get; set; }
    }
}
