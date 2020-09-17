using AutoMapper;
using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Services;
using GoingTo_API.Domain.Services.Geographic;
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
    [Route("/api/category/{categoryId}/places")]

    public class CategoryPlacesController : Controller 
    {
        private readonly IPlaceService _placeService;
        private readonly IMapper _mapper;

        public CategoryPlacesController(IPlaceService placeService, IMapper mapper)
        {
            _placeService = placeService;
            _mapper = mapper;
        }

        /// <summary>
        /// returns all the places that belong to this category
        /// </summary>
        /// <param name="categoryId" example="1"></param>
        /// <response code="200">returns all the places in the category.</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlaceResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var places = await _placeService.ListByCategoryIdAsync(categoryId);
            var resources = _mapper
                .Map<IEnumerable<Place>, IEnumerable<PlaceResource>>(places);
            return resources;
        }
    }
}
