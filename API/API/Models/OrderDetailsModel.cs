using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderDetailsModel
    {
        public  int ID { get; set; }

        public  int Quantity { get; set; }

        public  double Price { get; set; }

        public string ProductName { get; set; }

        public int orderId { get; set; }
    }
}
