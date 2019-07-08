using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class orderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int  ID { get; set; }

        public virtual int  Quantity { get; set; }

        public virtual double Price { get; set; }

        //reference of product 
        
        [ForeignKey("Product")]
        public virtual int? productId { get; set; }
        public  Product Product { get; set; }


        //refrence of order 
        [ForeignKey("Order")]
        public virtual int? orderId { get; set; }
        public  Order Order { get; set; }

    }
}
