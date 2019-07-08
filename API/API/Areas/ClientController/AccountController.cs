using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Areas.ClientController
{
    [EnableCors("CorsPolicy")]
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       
        AccountServices accountServices;
        public AccountController(UserManager<Users> userManager , SignInManager<Users> signInManager
           )
        {
            
            accountServices = new AccountServices(userManager, signInManager);
        }


        [Route("Register")]
        [HttpPost]
        public Task<string> Register ([FromBody]UserModel user)
        {
            return accountServices.PostApplicationUser(user);
        }


        [Route("Login")]
        [HttpPost]
        public Task<TokenModel> Login([FromBody]UserModel user)
        {
          return accountServices.LoginUser(user);         
            
        }


        [Route("Profile")]
        [HttpGet]
        public Task<UserModel> Profile([FromQuery]string Email)
        {
            return  accountServices.getProfile(Email) ;
        }
    }
}