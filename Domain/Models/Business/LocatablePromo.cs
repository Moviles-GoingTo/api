using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class LocatablePromo
    {
        public int Id { get; set; }
        public Promo Promo { get; set; }
        public int PromoId { get; set; }
        public Locatable Locatable { get; set; }
        public int LocatableId { get; set; }
    }
}
