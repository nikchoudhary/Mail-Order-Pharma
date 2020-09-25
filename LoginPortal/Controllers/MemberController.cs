using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoginPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoginPortal.Controllers
{
    public class MemberController : Controller
    {
        
        IConfiguration _config;
        public MemberController(IConfiguration config)
        {
            
            _config = config;
        }

        public ActionResult Login()
        {
            //_log4net.Info("Login initiated");

            return View();



        }
        [HttpPost]
        public ActionResult Login(Member obj)
        {
            string TokenForLogin;
            string data = JsonConvert.SerializeObject(obj);
            
            //Uri baseAddress = new Uri("https://localhost:44372/api/Auth/");
            
            try
            {
                TokenForLogin = GetToken("https://localhost:44377/api/Auth/", obj);
                if (!string.IsNullOrEmpty(TokenForLogin))
                {
                    return View("Index");
                }
                return View("Login");
            }
            catch (Exception ex)
            {
                //_log4net.Info("Exception In Authentication ActionResult");
                return View("Error1", ex);
            }
        }
        //[HttpPost]
        //public ActionResult MailOrder(Drug obj)
        //{
        //    Uri baseAddress = new Uri("https://localhost:44372/api");
        //    HttpClient client;
        //    client = new HttpClient();
        //    client.BaseAddress = baseAddress;

        //    Drug ls = new Drug();
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Drugs/" + obj.DrugId).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        ls = JsonConvert.DeserializeObject<Drug>(data);
        //    }
        //    return View(ls);

        //}
        
        public ActionResult Index()
        {
            return View();
        }
        
            

        // GET: MemberController
        static string GetToken(string url, Member user)
        {

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                //dynamic details = JObject.Parse(name);
                return name;
            }
        }
    }
}
