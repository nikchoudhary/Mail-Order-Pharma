using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LoginPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoginPortal.Controllers
{
    public class SubscriptionController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44318/api");
        HttpClient client;
        public SubscriptionController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Subs(Subscription ad)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            string data = JsonConvert.SerializeObject(ad);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Subscription/AddSubscription/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                ViewBag.Message = scheduleData;
                //Subscription r = JsonConvert.DeserializeObject<Subscription>(scheduleData);
                return View("Index");
            }
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
        public ActionResult Unsub(Subscription ad)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            string data = JsonConvert.SerializeObject(ad);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Subscription/RemoveSubscription/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                ViewBag.Message = scheduleData;
                //Subscription r = JsonConvert.DeserializeObject<Subscription>(scheduleData);
                return View("Index1");
            }
            return View();
        }

    }
}
