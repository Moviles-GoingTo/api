using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<CountryLanguage> CountryLanguages { get; set; }
    }
}
