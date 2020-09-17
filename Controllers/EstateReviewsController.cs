using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services.Business;
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
    [Route("/api/estate/{estateId}/reviews")]
    public class EstateReviewsController : Controller 
    {
        private readonly IReviewService _reviewService;
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public EstateReviewsController(IReviewService reviewService, IEstateService estateService, IMapper mapper)
        {
            _reviewService = reviewService;
            _estateService = estateService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the reviews of a Estate by EstateId
        /// </summary>
        /// <param name="estateId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetReviewsBypartnerId(int estateId)
        {
            var existingEstate = await _estateService.GetByIdAsync(estateId);

            int locatableId = existingEstate.Resource.LocatableId;

            var reviews = await _reviewService.ListByLocatableIdAsync(locatableId);

            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }
    }
}
