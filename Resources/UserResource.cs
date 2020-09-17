namespace GoingTo_API.Resources
{
    public class UserResource
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public WalletResource Wallet { get; set; }
    
    }
}
