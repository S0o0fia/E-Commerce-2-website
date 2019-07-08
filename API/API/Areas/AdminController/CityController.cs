using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.AdminController
{
    [EnableCors("CorsPolicy")]
    [Route("api/City")]
    [ApiController]
    public class CityController : ControllerBase
    {

        CityServices cityServices = new CityServices();
        [Route("Add")]
        [HttpPost("{id}")]
        public string PostAdd(City city)
        {
            return cityServices.AddCity(city);

        }

        [Route("Edit")]
        [HttpPut("{id}")]
        public string Edit(City city)
        {
            return cityServices.EditCity(city);

        }

        [Route("GetbyId")]
        [HttpGet("{id}")]
        public ActionResult<City> GetbyId([FromQuery]int id)
        {
            var city = cityServices.getCitybyId(id);
            return city;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<List<City>> Get()
        {
            return cityServices.getCity();
        }
    }
}
