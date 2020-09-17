using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Domain.Services.Interactions
{
    public interface IReviewService
    {
        Task<ReviewResponse> SaveAsync(Review review);
        Task<ReviewResponse> UpdateAsync(int reviewId, Review review);
        Task<ReviewResponse> DeleteAsync(int reviewId);
        Task<ReviewResponse> GetByIdAsync(int reviewId);
        Task<IEnumerable<Review>> ListByUserProfileIdAsync(int userProfileId);
        Task<IEnumerable<Review>> ListByLocatableIdAsync(int locatableId);
    }
}
