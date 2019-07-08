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

namespace API.Areas.ClientController
{
    [EnableCors("CorsPolicy")]
    [Route("api/OrderDetails")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        OrderDetailsServices orderDetailsServices = new OrderDetailsServices();
        [Route("Add")]
        [HttpPost]
        public string PostAdd(OrderDetailsModel orderDetails)
        {
            return orderDetailsServices.AddOrderdetails(orderDetails);

        }



        [Route("GetbyId")]
        [HttpGet("{id}")]
        public ActionResult<List<orderDetails>> GetbyUser([FromQuery] int id)
        {
            var orderdetails = orderDetailsServices.GetOrderDetails(id);
            return orderdetails;
        }
    }
}