using IdentitySampleApi.BusinessLogicLayer.Interfaces;
using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IdentitySampleApi.PresentationLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
        private IThingService _thingService;

        public ThingController(IThingService thingService)
        {
            _thingService = thingService;
        }

        // GET: api/Thing
        [HttpGet]
        public IEnumerable<GetThingDTO> Get()
        {
            List<GetThingDTO> thingDTOs = _thingService.GetAllThing();

            return thingDTOs;
        }

        // GET: api/Thing/5
        [Authorize(Roles = Entities.Role.Admin)]
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return $"Removed element with id={id}";
        }

        // POST: api/Thing
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Thing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
