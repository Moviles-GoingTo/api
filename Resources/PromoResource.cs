using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Resources
{
    public class PromoResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public float Discount { get; set; }
        public int PartnerId { get; set; }
    }
}
