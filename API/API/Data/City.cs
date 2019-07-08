using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  virtual int ID { get; set; }

        public virtual string Name { get; set; }

        //refrence of Country here
        //refernce of country
        [ForeignKey("Country")]
        public virtual int? countryId { get; set; }
        public virtual Country Country { get; set; }


        public ICollection<Users> Users { get; set; }
    }
}
