using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Resources;
using GoingTo_API.Resources.SaveResources;

namespace GoingTo_API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveProfileResource, UserProfile>();
            CreateMap<SaveWalletResource, Wallet>();
            CreateMap<SaveAchievementResource, Achievement>();
            CreateMap<SavePlaceResource, Place>();
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveReviewResource, Review>();
            CreateMap<SaveLanguageResource, Language>();
            CreateMap<SaveCurrencyResource, Currency>();
            CreateMap<SaveTipResource, Tip>();
            CreateMap<SavePlanResource, Plan>();
            CreateMap<SavePartnerResource, Partner>();
            CreateMap<SaveBenefitResource, Benefit>();
            CreateMap<SavePartnerProfileResource, PartnerProfile>();
            CreateMap<SavePromoResource, Promo>();
            CreateMap<SaveEstateResource, Estate>();
        }
    }
}

