using AutoMapper;
using GoingTo_API.Domain.Models;
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
    [Authorize]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns one review  by id
        /// </summary>
        /// <param name="id" example="1">the review Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);

        }
        /// <summary>
        /// creates a review in the system
        /// </summary>
        /// <param name="resource">a review resource</param>
        /// <response code="201">creates a review in the system</response>
        /// <response code="400">unable to create the review due validation</response>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.SaveAsync(review);

            if (!result.Success)
                return BadRequest(result.Message);

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }

        /// <summary>
        /// updates a review in the system
        /// </summary>
        /// <param name="resource">A review resource</param>
        /// <param name="id">The id of the review to update</param>
        /// <response code="201">Updates a review in the system</response>
        /// <response code="400">Unable to update the review due validation</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveReviewResource resource)
        {
            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.UpdateAsync(id, review);

            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }
        /// <summary>
        /// deletes a review in the system
        /// </summary>
        /// <response code="201">Deletes a review in the system</response>
        /// <response code="400">Unable to delete the review due validation</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _reviewService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
            return Ok(reviewResource);
        }
    }
}
