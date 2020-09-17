using AutoMapper;
using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public float Stars { get; set; }
        public string ReviewedAt { get; set; }
        public int LocatableId { get; set; }
        public Locatable Locatable { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

    }
}
