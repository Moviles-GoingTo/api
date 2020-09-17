using AutoMapper;
using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Services.Geographic;
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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the categories in the system
        /// </summary>
        /// <response code="200">returns all the categories in the system</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }
        /// <summary>
        /// returns a category by id
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);

        }
        /// <summary>
        /// add a category in the system
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }
        /// <summary>
        /// update a category in the system
        /// </summary>
        /// <param name="id" example="1"></param>
        /// <param name="resource" example="Turismo aventurero"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }
        /// <summary>
        /// delete a category from the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}

