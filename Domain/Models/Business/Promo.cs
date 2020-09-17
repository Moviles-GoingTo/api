using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Business
{
    public class Promo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public float Discount { get; set; }
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }
        public List<LocatablePromo> LocatablePromos { get; set; }
    }
}
