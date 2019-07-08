using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        
        public virtual DateTime Date { get; set; }


        //refrence of user here 
        [ForeignKey("Users")]
        public virtual string userId { get; set; }
        public  Users Users { get; set; }



        public ICollection<orderDetails> orderDetails { get; set; }
    }
}
