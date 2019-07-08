using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        public  string Name { get; set; }

        public  int availableQuantity { get; set; }

        public  int limitQuantity { get; set; }

        public  double Price { get; set; }

        public  string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

    }
}
