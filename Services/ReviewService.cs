using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Repositories.Interactions;
using GoingTo_API.Domain.Services.Communications;
using GoingTo_API.Domain.Services.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IUnitOfWork unitOfWork) 
        {
            _reviewRepository = reviewRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ReviewResponse> SaveAsync(Review review)
        {
            try
            {
                await _reviewRepository.AddAsync(review);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(review);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while saving the Review: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> UpdateAsync(int reviewId, Review review)
        {
            var existingReview = await _reviewRepository.FindById(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review not found");

            existingReview.Comment = review.Comment;
            existingReview.Stars = review.Stars;

            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while updating Review: {ex.Message}");
            }
        }
        public async Task<ReviewResponse> DeleteAsync(int reviewId)
        {
            var existingReview = await _reviewRepository.FindById(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review not found");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while deleting Review: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> GetByIdAsync(int reviewId)
        {
            var existingReview = await _reviewRepository.FindById(reviewId);

            if (existingReview == null)
                return new ReviewResponse("Review not found");
            return new ReviewResponse(existingReview);
        }

        public async Task<IEnumerable<Review>> ListByUserProfileIdAsync(int userProfileId)
        {
            return await _reviewRepository.ListByUserProfileIdAsync(userProfileId);
        }

        public async Task<IEnumerable<Review>> ListByLocatableIdAsync(int locatableId)
        {
            return await _reviewRepository.ListByLocatableIdAsync(locatableId);
        }
    }
}
