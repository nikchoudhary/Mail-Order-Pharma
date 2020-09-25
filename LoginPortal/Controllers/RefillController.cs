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
    public class RefillController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44322/api");
        HttpClient client;
        public RefillController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetById(int Subid)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Refill/RefillStatus/" + Subid).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                Refill r = JsonConvert.DeserializeObject<Refill>(scheduleData);
                return View("RefillStatus", r);
            }
            return View();
        }

           
        [HttpPost]
        public IActionResult RefillStatus(Refill obj)
        {
            return View();
        }

        public IActionResult IndexDue()
        {
            return View();
        }

        public ActionResult GetDues(int Subid, DateTime fromdate)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Refill/RefillDueAsOfDate/" + Subid +"/"+ fromdate.ToString("yyyy-MM-dd")).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                IEnumerable<Refill> r = JsonConvert.DeserializeObject<List<Refill>>(scheduleData);
                return View("RefillDues", r);
            }
            return View();


        }
        [HttpPost]
        public IActionResult RefillDues(Drug obj)
        {
            return View();
        }

        public IActionResult IndexAdhoc()
        {
            return View();
        }
        public ActionResult Adhocdrug(RefillOrder ad)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            string data = JsonConvert.SerializeObject(ad);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Refill/requestAdhocRefill/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                Refill r = JsonConvert.DeserializeObject<Refill>(scheduleData);
                return View("AdhocRefill", r);
            }
            return View();


        }
        [HttpPost]
        public IActionResult AdhocRefill(Refill obj)
        {
            return View();
        }

    }
}
