using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Extensions;
using GoingTo_API.Resources;
using GoingTo_API.Resources.SaveResources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoingTo_API.Controllers
{
    [Authorize]
    [Route("/api/services")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }
        /// <summary>
        /// returns all the services in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var services = await _serviceService.ListAllAsync();
            if(services==null)
                return BadRequest(ModelState.GetErrorMessages());
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return Ok(resources);
        }
        /// <summary>
        /// returns a service by id.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int serviceId)
        {
            var service = await _serviceService.GetByIdAsync(serviceId);
            if (service == null)
                return BadRequest(ModelState.GetErrorMessages());
            var resource = _mapper.Map<Service, ServiceResource>(service.Resource);
            return Ok(resource);
        }
        /// <summary>
        /// create a service in the system.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.SaveAsync(service);

            if (!result.Success)
                return BadRequest(ModelState.GetEnumerator());
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
        }
        /// <summary>
        /// modify a service in the system.
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromBody] SaveServiceResource resource, int id )
        {
            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.UpdateAsync(id,service);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            return Ok(serviceResource);
            
        }

    }
}
