using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Areas.AdminController
{
    [EnableCors("CorsPolicy")]
    [Route("api/Product")]
    [ApiController]
    public class PoductController : ControllerBase
    {
        private ProductServices productServices = new ProductServices();

        //get all product 
        [Route("Get")]
        [HttpGet("{id}")]
        public Task<List<ProductModel>> Get([FromQuery]int id)
        {
            var product = productServices.GetProductwithCatId(id);
            return product;
        }

        [Route("GetOne")]
        [HttpGet("{id}")]
        public Task<ProductModel>GetOne([FromQuery]int id)
        {
            var product = productServices.GetProduct(id);
            return product;
        }


        [Route("Add")]
        [HttpPost]
        public string PostAdd(ProductModel product)
        {
            return productServices.AddProduct(product);

        }


        //update product 
        [Route("Edit")]
        [HttpPut("{id}")]
        public string Edit(ProductModel product)
        {
            return productServices.EditProduct(product);

        }


        //update product 
        [Route("Delete")]
        [HttpDelete("{id}")]
        public string Delete(ProductModel product)
        {
            return productServices.DeleteProduct(product);

        }
    }
}