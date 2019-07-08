using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderDetailsServices
    {
        ApplicationDbContext context;
        public OrderDetailsServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
        }

        //add order details
        public string AddOrderdetails(OrderDetailsModel orderDetails)
        {
            try { 
            int productid = context.Products.Where(p => p.Name == orderDetails.ProductName).Select(p => p.ID).FirstOrDefault();

            orderDetails orderd = new orderDetails
            {
              Price = orderDetails.Price , 
              productId = productid , 
              Quantity = orderDetails.Quantity , 
              orderId = orderDetails.orderId 
            };
            context.OrderDetails.Add(orderd);
            context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }


        //get orderdetials of order
        public List<orderDetails> GetOrderDetails (int orderid)
        {
            return context.OrderDetails.Where(od => od.orderId == orderid).ToList();
        }

    }
}
