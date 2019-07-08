using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CountryServices
    {
        ApplicationDbContext context;
        public CountryServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
        }
        //Add City
        public string AddCountry(string Name)
        {
            try
            {
                Country Country = new Country();
                Country.Name = Name;
                context.Countries.Add(Country);
                context.SaveChanges();
                return "Scuess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }

        //delete Country 
        public string DeleteCountry(string Name)
        {
            try
            {
                Country Country = new Country { Name = Name };
                context.Countries.Attach(Country);
                context.Countries.Remove(Country);
                context.SaveChanges();
                return "Scuess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }

        //Edit Country
        public string EditCountry(Country country)
        {
            try
            {
                Country Country = context.Countries.Where(c => c.ID == country.ID).FirstOrDefault();
                Country.Name = country.Name;
                context.SaveChanges();
                return "Scuess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }

        //get all Country
        public List<Country> getCountry()
        {
            return context.Countries.ToList();
        }


        //get specific Country 
        public Country getCountrybyId(int id)
        {
            return context.Countries.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}
