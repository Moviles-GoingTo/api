using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class CountryCurrency
    {
        public int Id { get; set; }
        
        public Country Country { get; set; }
        public int CountryId { get; set; }

        public Currency Currency { get; set; }
        public int CurrencyId { get; set; }
    }
}
