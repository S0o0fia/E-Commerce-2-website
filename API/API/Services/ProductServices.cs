using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductServices
    {
        ApplicationDbContext context;
        public ProductServices()
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);
        }

        //create product 
        public string AddProduct (ProductModel product)
        {
            try
            {
                int catid = context.Categories.Where(c => c.Name == product.Name).Select(c => c.ID).FirstOrDefault();
                Product productdb = new Product
                {
                    Name = product.Name,
                    catId = catid,
                    Description = product.Description,
                    availableQuantity = product.availableQuantity,
                    limitQuantity = product.limitQuantity,
                    Price = product.Price,
                    Image = product.Image
                };

                context.Products.Add(productdb);
                context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "failed";
            }
            
        }


        //get specific products
        public async Task<List<ProductModel>> GetProductwithCatId (int catId)
        {

            //  var list = context.database.("getallproducts @catid",parameters:new { catid });
            //return list as list<productmodel>;
            using (SqlConnection sql = new SqlConnection("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true"))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllProducts", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@catId" , catId));
                    var response = new List<ProductModel>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            response.Add(new ProductModel {
                                ID = Convert.ToInt32(reader["ID"]) ,
                                Name = reader["Name"].ToString() ,
                                availableQuantity  = Convert.ToInt32(reader["availableQuantity"]) ,
                                limitQuantity = Convert.ToInt32(reader["limitQuantity"]) ,
                                Description = reader["Description"].ToString() ,
                                Image = reader["Image"].ToString() ,
                                Price = Convert.ToInt32(reader["Price"]) ,
                                Category = reader["Category"].ToString()

                            });
                        }
                        return response;
                    }
                }
            }

        }

        //get one product 
        public async Task<ProductModel> GetProduct(int pId)
        {

            var product = context.Products.Where(p => p.ID == pId).FirstOrDefault();
            ProductModel newproduct = new ProductModel {Name = product.Name ,
            availableQuantity = product.availableQuantity ,
            Description = product.Description ,
            ID = product.ID ,
            Category = "" ,
            Image = product.Image ,
            limitQuantity = product.limitQuantity ,
            Price = product.Price};

            return newproduct;
            

        }

        //edit Product 
        public string EditProduct(ProductModel product)
        {
            try
            {
                Product p = context.Products.Where(p1 => p1.ID == product.ID).FirstOrDefault();
                p.Name = product.Name;
                p.Image = product.Image;
                p.limitQuantity = product.limitQuantity;
                p.Price = product.Price;
                p.Description = product.Description;
                p.availableQuantity = product.availableQuantity;
                int catid = context.Categories.Where(c => c.Name == product.Category).Select(c => c.ID).FirstOrDefault();
                p.catId = catid;
                context.SaveChanges();
                return "Sucess";
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }

        //delete product 
        public string DeleteProduct(ProductModel product)
        {
            try
            {
                Product p = context.Products.Where(p1 => p1.ID == product.ID).FirstOrDefault();
                context.Products.Remove(p);
                context.SaveChanges();
                return "Sucess";
            }
            catch(Exception ex)
            {
                return "faild";
            }
        }


    }
}
