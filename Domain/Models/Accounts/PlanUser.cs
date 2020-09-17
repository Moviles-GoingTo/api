using GoingTo_API.Domain.Models.Business;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Models.Accounts
{
    public class PlanUser
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
