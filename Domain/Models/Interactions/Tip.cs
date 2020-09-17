using AutoMapper;
using GoingTo_API.Domain.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models
{
    public class Tip
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
