using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacy_Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        readonly log4net.ILog _log4net;

        public AuthController(IConfiguration config)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
            _config = config;
        }
        string token;

        [HttpPost]
        public IActionResult Login([FromBody] Authorization auth)
        {
            _log4net.Info(" Login Initiated");
            IActionResult response = Unauthorized();
            var member = AuthenticateUser(auth);
            if (member != null)
            {
                var tokenString = GenerateJSONWebToken(member);
                return Ok(tokenString);
                
            }
            
            
            //Uri baseAddress = new Uri("https://localhost:port/controller");
            //HttpClient client = new HttpClient();
            //client.BaseAddress = baseAddress;
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "token");
            //client.GetAsync
            
            return response;
            
            
        }
        //public IActionResult DrugService()
        //{
        //    Uri baseAddress = new Uri("https://localhost:port/controller");
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = baseAddress;
        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "token");
        //    client.GetAsync
        //}

        private string GenerateJSONWebToken(Authorization userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private Authorization AuthenticateUser(Authorization login)
        {
            Authorization user = null;

            Dictionary<string, string> ValidUsersDictionary = new Dictionary<string, string>()
           {
               {"oliva","adak"},
               {"nikhil","nikhil"},
               {"ahon","saha"},
               {"tamoghno","tamoghno"}
           };

            if (ValidUsersDictionary.Any(u => u.Key == login.Name && u.Value == login.Password))
            {
                user = new Authorization { Name = login.Name, Password = login.Password };
            }

            return user;
        }

    }      
}
