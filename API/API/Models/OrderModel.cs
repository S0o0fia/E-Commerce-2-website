using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class OrderModel
    {

        public string Date { get; set; }
        public string Cutomername { get; set; }
        public List<OrderDetailsModel> orderDetails { get; set; }

    }
}
