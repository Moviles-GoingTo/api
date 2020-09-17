using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/userprofile/{userProfileId}/reviews")]
    [Produces("application/json")]
    public class UserReviewsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;

        public UserReviewsController(IReviewService reviewService, IMapper mapper) 
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }
        /// <summary>
        /// returns all the reviews of a user
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetAllByUserIdAsync(int userProfileId)
        {
            var reviews = await _reviewService.ListByUserProfileIdAsync(userProfileId);
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }
    }
}
