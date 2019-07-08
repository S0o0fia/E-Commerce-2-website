using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Product

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual int availableQuantity { get; set; }

        public virtual int limitQuantity { get; set; }

        public virtual double Price { get; set; }

        public virtual string Description { get; set; }

        public virtual string Image { get; set; }


        //put the reference of the category 
        [ForeignKey("Category")]
        public virtual int? catId { get; set; }
        public  Category Category { get; set; }



        public ICollection<orderDetails> orderDetails { get; set; }

    }
}
