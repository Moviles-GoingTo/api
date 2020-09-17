using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Services.Communications
{
    public class ProfileResponse : BaseResponse<UserProfile>
    {
        public UserProfile Profile { get; private set; }

        public ProfileResponse(string message) : base(message) { }

        public ProfileResponse(UserProfile profile) : base(profile) { }
    }
}