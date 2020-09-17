namespace GoingTo_API.Domain.Models.Accounts
{
    public class Wallet
    {
        public int Id { get; set; }
        public int Points { get; set; }

        public User User { get; set; }
    }
}
