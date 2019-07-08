using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Areas.AdminController
{
    [EnableCors("CorsPolicy")]
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
          CategoryServices categoryServices = new CategoryServices();


        [Route("Add")]
        [HttpPost]
        public string PostAdd(Category cat)
        {
            return categoryServices.AddCategory(cat.Name);
            
        }

        [Route("Edit")]
        [HttpPut("{id}")]
        public string Edit(Category cat )
        {
            return categoryServices.EditCategory(cat);

        }

        [Route("Get")]
        [HttpGet("{id}")]
        public  ActionResult<Category> Get([FromQuery]int id)
        {
            var category = categoryServices.getCategriesbyId(id);
            return category;
        }
    }
}