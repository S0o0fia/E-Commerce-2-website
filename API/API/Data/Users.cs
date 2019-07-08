using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Users : IdentityUser
    {
        public virtual string FullName { get; set; }

        //refernce of country
        [DisplayName("Country")]
        public virtual int? countryId { get; set; }
        [ForeignKey("countryId")]
        public virtual Country Country { get; set; }

        //refernce of city
        [DisplayName("City")]
        public virtual int? cityId { get; set; }
        [ForeignKey("cityId")]
        public virtual  City City { get; set; }




        public ICollection<Order> Orders { get; set; }

    }
}
