using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public string ShortName { get; set; }

        public List<CountryCurrency> CountryCurrencies { get; set; }
    }
}
