using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentitySampleApi.BusinessLogicLayer.Interfaces;
using IdentitySampleApi.DataTransferObjectLayer.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentitySampleApi.PresentationLayer.Controllers
{
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
        public IEnumerable<ThingDTO> Get()
        {
            List<ThingDTO> thingDTOs = _thingService.GetAllThing();

            return thingDTOs;
        }

        // GET: api/Thing/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
