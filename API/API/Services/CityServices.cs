using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CityServices
    {
        ApplicationDbContext context;
        public CityServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
        }
        //Add City
        public string AddCity(City city)
        {
            try
            {
                City City = new City();
                City.Name = city.Name;
                City.countryId = city.ID;
                context.Cities.Add(City);
                context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }

        //delete City 
        public string DeleteCity(string Name)
        {
            try
            {
                City City = new City { Name = Name };
                context.Cities.Attach(City);
                context.Cities.Remove(City);
                context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
        }

        //Edit City
        public string EditCity(City city)
        {
            try
            {
                City City = context.Cities.Where(c => c.ID == city.ID).FirstOrDefault();
                City.Name = city.Name;
                context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
           
        }

        //get all City
        public List<City> getCity()
        {
            return context.Cities.ToList();
        }


        //get specific City 
        public City getCitybyId(int id)
        {
            return context.Cities.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}
