using GoingTo_API.Domain.Models.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PartnerProfile PartnerProfile { get; set; }
        public List<Promo> Promos { get; set; }
        public List<Estate> Estates { get; set; }
    }
}
