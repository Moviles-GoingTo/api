using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        
        public User User { get; set; }

        public Locatable Locatable { get; set; }
        public int LocatableId { get; set; }
    }
}
