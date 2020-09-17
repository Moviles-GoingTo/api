using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoingTo_API.Controllers
{
    
    [Route("/api/locatables/{locatableId}/reviews")]
    public class LocatableReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly ILocatableService _locatableService;
        private readonly IMapper _mapper;

        public LocatableReviewsController(IReviewService reviewService, ILocatableService locatableService, IMapper mapper)
        {
            _reviewService = reviewService;
            _locatableService = locatableService;
            _mapper = mapper;
        }


        /// <summary>
        /// returns all reviews of a locatable in the system
        /// </summary>
        /// <response code="200">returns all reviews of a locatable in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReviewsByLocatableIdAsync(int locatableId)
        {
            var existingLocatable = await _locatableService.GetByIdAsync(locatableId);
            if (!existingLocatable.Success)
                return BadRequest(existingLocatable.Message);

            var reviews = await _reviewService.ListByLocatableIdAsync(locatableId);
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);

            return Ok(resources);
        }

    }   
}
