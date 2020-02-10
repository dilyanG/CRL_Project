using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CRL.DataModel.Entities;
using CRL.DataService.Interfaces;
using CRL.DataService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRL.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/City")]
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        private readonly IMapper mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            this.cityService = cityService;
            this.mapper = mapper;
        }

        // GET: api/City
        [HttpGet]
        [Route("byId/{id}")]
        public IEnumerable<string> GetById(int id)
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/City/all
        [HttpGet]
        [Route("all")]
        public OkObjectResult GetAll()
        {
            var result = mapper.Map<List<CityEntity>,List<CityViewModel>>(this.cityService.GetAll());
            return Ok(result);
        }

        // GET: api/City/5
        [HttpGet("{id}", Name = "GetCity")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/City/5
        [HttpGet("ByName/{name}")]
        public OkObjectResult GetByName(string name)
        {
            var result = mapper.Map<List<CityEntity>, List<CityViewModel>>(this.cityService.GetAllByName(name));
            return Ok(result);
        }

        // POST: api/City
        [HttpPost]
        public OkResult Post([FromBody]CityViewModel city)
        {
            CityEntity entity = mapper.Map<CityEntity>(city);
            this.cityService.AddCity(entity);
            return Ok();
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
