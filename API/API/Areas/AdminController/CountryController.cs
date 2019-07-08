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
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        CountryServices countryServices = new CountryServices();
        [Route("Add")]
        [HttpPost]
        public string PostAdd(Country country)
        {
            return countryServices.AddCountry(country.Name);

        }

        [Route("Edit")]
        [HttpPut("{id}")]
        public string Edit(Country country)
        {
            return countryServices.EditCountry(country);

        }

        [Route("GetbyId")]
        [HttpGet("{id}")]
        public ActionResult<Country> GetbyId([FromQuery]int id)
        {
            var country = countryServices.getCountrybyId(id);
            return country;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<List<Country>> Get()
        {
            return countryServices.getCountry();
        }

    }
}