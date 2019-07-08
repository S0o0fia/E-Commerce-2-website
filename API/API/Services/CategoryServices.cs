using API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CategoryServices
    {
       

        ApplicationDbContext context;
        public CategoryServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
        }
        //Add category
        public string AddCategory(string cat)
        {

            Category category = new Category();
            category.Name = cat;
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return "Sucess";

                 }
            catch (Exception ex)
            {
                return "failed";
            }


        }

        //delete category 
        public void DeleteCategory(string Name)
        {
            Category category = new Category { Name = Name};
            context.Categories.Attach(category);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        //Edit category
        public string EditCategory(Category category)
        {
            try
            {
                Category getcategory = context.Categories.Where(c => c.ID == category.ID).FirstOrDefault();
                getcategory.Name = category.Name;
                context.SaveChanges();
                return "Sucess"; 

            }
            catch(Exception ex)
            {
                return "failed";
            }
            }

        //get all categories
            public List<Category> getCategries()
        {
            return context.Categories.ToList();
        }


        //get specific category 
        public Category getCategriesbyId(int id)
        {
            return context.Categories.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}
