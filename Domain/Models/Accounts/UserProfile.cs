using System.Collections.Generic;

namespace GoingTo_API.Domain.Models.Accounts
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Tip> Tips { get; set; } = new List<Tip>();
        public int UserId { get; set; }
        public User User { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
