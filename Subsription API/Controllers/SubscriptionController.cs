using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MailOrderPharmacy_Subsription.Modules;
//using MailOrderPharmacy_Subsription.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacy_Subsription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        //private ISubscription _con;

        public SubscriptionController()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(SubscriptionController));
            //_con = con;
        }
        public static List<SubscriptionDetails> ls = new List<SubscriptionDetails>
        {
            new SubscriptionDetails
            {
                Drug_ID=1,
                Sub_id=7,
                RefillOccurrence="Weekly",
                Member_Location="Pune"
            },
            new SubscriptionDetails
            {
                Drug_ID=1,
                Sub_id=8,
                RefillOccurrence="Monthly",
                Member_Location="Pune"
            }
        };
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ls.Where(x => x.Sub_id == id).FirstOrDefault();
            return Ok(item);
        }


        // POST api/<SubscriptionController>
        [HttpPost("AddSubscription")]
        public ActionResult AddSubscription(SubscriptionDetails obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            int x = obj.Drug_ID;
            Uri baseAddress = new Uri("https://localhost:44372/api");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;
            
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Drugs/" + x).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                Drug drug = JsonConvert.DeserializeObject<Drug>(data);
                if (drug.Quantity > 0)
                {
                    ls.Add(obj);

                    return Ok("Added");
                }
                return BadRequest("Unavailable");
                
            }

            return BadRequest();
        }
        [HttpPost("RemoveSubscription")]
        public ActionResult RemoveSubscription(SubscriptionDetails obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            int x = obj.Sub_id;
            Uri baseAddress = new Uri("https://localhost:44322/api");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Refill/" + x).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                Refill refill = JsonConvert.DeserializeObject<Refill>(data);
                if (refill.Status == "clear")
                {
                    ls.Remove(obj);
                    return Ok("done");
                }
                return BadRequest("Clear the Dues");
            }
            return BadRequest();
        }

        // PUT api/<SubscriptionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
