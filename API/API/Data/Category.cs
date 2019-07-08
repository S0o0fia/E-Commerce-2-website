using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        //list of products
        public virtual ICollection<Product> Products { get; set; }
        //self reference of relation 

        public virtual int? parentId { get; set; }

        [ForeignKey("parentId")]
        public  Category category { get; set; }
    }
}
