using API.Data;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class AccountServices
    {
        ApplicationDbContext context;
        private UserManager<Users> _userManager;
        private SignInManager<Users> _signInManager;
        public AccountServices(UserManager<Users> userManager,
        SignInManager<Users> signInManager)
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>();
            option.UseSqlServer("Server=DESKTOP-EGQI7VO;Database=Crocheto;Trusted_Connection=True;MultipleActiveResultSets=true");
            context = new ApplicationDbContext(option.Options);

            _userManager = userManager;
            _signInManager = signInManager;

        }

        //register user 
        public async Task<string> PostApplicationUser(UserModel User)
        {
            int UsercountryId = context.Countries.Where(c => c.Name == User.Country).Select(c => c.ID).FirstOrDefault();
            int UsercityId = context.Cities.Where(cty => cty.Name == User.City).Select(cty => cty.ID).FirstOrDefault();
            var user = new Users()
            {
                Email = User.Email,
                UserName = User.UserName,
                FullName = User.FullName,
                PhoneNumber = User.PhoneNumber,
                cityId = UsercityId,
                countryId = UsercountryId
            };

            try
            {
                var result = await _userManager.CreateAsync(user, User.Password);
                return "Sucess";
            }
            catch (Exception ex)
            {
                return "failed";
            }
        }


        //loginUser 
        public async Task<TokenModel> LoginUser(UserModel User)
        {
            var user = await _userManager.FindByEmailAsync(User.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, User.Password))
            {
                var tokenDescritor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim ("UserID" , user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")),
                        SecurityAlgorithms.HmacSha256Signature),

                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var secuirtyToken = tokenHandler.CreateToken(tokenDescritor);
                var token = tokenHandler.WriteToken(secuirtyToken);
                TokenModel tok = new TokenModel { token = token };
                return tok;

            }
            else
            {
                TokenModel tok = new TokenModel { token = "failed" };
                return tok;
            }
        }


        public async Task<UserModel> getProfile(string email)
        {
            Users user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                CountryServices services = new CountryServices();
                var Country = context.Countries.Where(c => c.ID == user.countryId).Select(c => c.Name).FirstOrDefault();
                var City = context.Cities.Where(C => C.ID == user.cityId).Select(c => c.Name).FirstOrDefault();
                UserModel userModel = new UserModel
                {
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Country = Country,
                    City = City
                };
                return userModel;
            }

            return null;
        }
    }
}
