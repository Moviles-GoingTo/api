using GoingTo_API.Domain.Models.Accounts;

namespace GoingTo_API.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
         
        public UserResponse(string message) : base(message){ }
        public UserResponse(User user) : base(user) { }

    }
}
