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
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        OrderServices orderServices = new OrderServices();

        [Route("Add")]
        [HttpPost]
        public string PostAdd([FromBody] UserLoginModel user)
        {
            return orderServices.AddOrder(user.Email);
        }

        [Route("GetbyId")]
        [HttpGet("{id}")]
        public ActionResult<Order> GetbyId([FromQuery]int id)
        {
            var order = orderServices.getOrder(id);
            return order;
        }

        [Route("GetbyUser")]
        [HttpGet()]
        public ActionResult<List<Order>> GetbyUser([FromBody]string Email)
        {
            var order = orderServices.getUserOrders(Email);
            return order;
        }

        [Route("Get")]
        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return orderServices.getallOrders();
        }


        [Route("SendMail")]
        [HttpGet("{id}")]
        public ActionResult<string> sendMail([FromQuery]int id)
        {
            
            orderServices.SendEmail(id);
            return "Sucess";
            
        }
    }
}