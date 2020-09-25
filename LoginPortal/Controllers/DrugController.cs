using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LoginPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LoginPortal.Controllers
{
    public class DrugController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44372/api");
        HttpClient client;
        public DrugController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        // GET: DrugController
        //public IActionResult actionResult

        public ActionResult Index()
        {

            
            return View();
        }
        
        public ActionResult GetById(int drugid)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress+"/Drugs/"+ drugid).Result;
            if (response.IsSuccessStatusCode)
            {
                string scheduleData = response.Content.ReadAsStringAsync().Result;
                Drug drug = JsonConvert.DeserializeObject<Drug>(scheduleData);
                return View("DrugDetailsid", drug);
            }
            return View();

        }
        [HttpPost]
        public IActionResult DrugDetailsid(Drug obj)
        {
            return View();
        }

        // GET: DrugController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DrugController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrugController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DrugController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DrugController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DrugController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
