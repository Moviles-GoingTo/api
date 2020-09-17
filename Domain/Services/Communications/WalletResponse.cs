using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Services.Communications
{
    public class WalletResponse : BaseResponse<Wallet>
    {

        public WalletResponse(string message) : base(message) { }

        public WalletResponse(Wallet wallet) : base(wallet) { }
    }
}