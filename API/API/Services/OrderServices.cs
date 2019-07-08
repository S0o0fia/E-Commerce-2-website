using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace API.Services
{
    public class OrderServices
    {
        ApplicationDbContext context;
        OrderDetailsServices OrderDetailsServices; 
        public OrderServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
            OrderDetailsServices = new OrderDetailsServices();
        }
        //add order
        public string AddOrder(string Email)
        {
            try
            {
                string userId = context.Users.Where(u => u.Email == Email).Select(u => u.Id).FirstOrDefault();
                Order order = new Order
                {
                    userId = userId,
                    Date = DateTime.Now
                };
                context.Orders.Add(order);
                context.SaveChanges();
                return "Sucess";
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }

        internal ActionResult<List<Order>> getOrder()
        {
            throw new NotImplementedException();
        }

        //get orders
        public List<Order> getallOrders()
        {
            return context.Orders.ToList();
        }

        //get user orders
        public List<Order> getUserOrders(string Email)
        {
            string userId = context.Users.Where(u => u.Email == Email).Select(u => u.Id).FirstOrDefault();
            return context.Orders.Where(u=>u.userId == userId).ToList();
        }

        //get specefic order
        //get user orders
        public Order getOrder(int id)
        {
            
            return context.Orders.Where(u => u.ID == id).FirstOrDefault();
        }


        public OrderModel sendorder(int id)
        {
            OrderModel orderModel = new OrderModel();
            orderModel.orderDetails = new List<OrderDetailsModel>();
            var order = context.Orders.Where(u => u.ID == id).FirstOrDefault();
            var orderdetails = OrderDetailsServices.GetOrderDetails(order.ID);
            var user = context.Users.Where(u => u.Id == order.userId).Select(u => u.FullName).FirstOrDefault();
            orderModel.Date = order.Date.ToString();
            orderModel.Cutomername = user;
            foreach (var item in orderdetails)
            {
                var product = context.Products.Where(p => p.ID == item.productId).Select(p => p.Name).FirstOrDefault();
                orderModel.orderDetails.Add(new OrderDetailsModel
                {
                    Price = item.Price,
                    ProductName = product,
                    Quantity = item.Quantity,
                    orderId = order.ID
                    
                });
           
            }
            return orderModel;
        }


        public void SendEmail(int id)
        {
            OrderModel orderModel = sendorder(id);
            EmailModel email = new EmailModel();
            email.Subject = "Order from Crocheto";
            email.Email = "Kamelsafaa960@gmail.com";
            string body = "This is order done by  " + orderModel.Cutomername + "in date " + orderModel.Date;
            foreach (var item in orderModel.orderDetails)
            {
                body += "  price = " + item.Price +
                       "  Quantitiy  " + item.Quantity +
                       "  Product    " + item.ProductName;
            }
            email.Message = body;
            //SmtpClient client = new SmtpClient("mysmtpserver");
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("Crocheto@hotmail.com");
            //mailMessage.To.Add(email.Email);
            //mailMessage.Body = email.Message ;
            //mailMessage.Subject = email.Subject;

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Crocheto",
            "ECrocheto@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("Admin",
            "kamelsafaa@gmail.com");
            message.To.Add(to);

            message.Subject = email.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = email.Message;
            message.Body = bodyBuilder.ToMessageBody();

            var emailClient = new MailKit.Net.Smtp.SmtpClient();
            emailClient.Connect("smtp.gmail.com", 25, false);
            emailClient.Send(message);
            emailClient.Disconnect(true);
            emailClient.Dispose();
        }
    }
}
