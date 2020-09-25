using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MailOrderPharmacy_RefillService.Models;
using MailOrderPharmacy_RefillService.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MailOrderPharmacy_RefillService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefillController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IRefill _db;
        //comment

        public RefillController(IRefill db)
        {
            _db = db;

            _log4net = log4net.LogManager.GetLogger(typeof(RefillController));
        }
        // GET: api/<RefillController>/7
        [HttpGet("RefillStatus/{id}")]
        public IActionResult RefillStatus(int id)
        {
            
            try
            {
                var item = _db.viewRefillStatus(id);
                return Ok(item);
            }
            catch

            {
                return BadRequest();
            }

        }


        [HttpGet("RefillDueAsOfDate/{id}/{FromDate}")]
        public IActionResult RefillDueAsOfDate(int id, DateTime FromDate)
        {
            Refill fill = new Refill();
            List<RefillDetails> m = new List<RefillDetails>();
            //List<string> myList = new List<string>();


            string data = JsonConvert.SerializeObject(id);

            //int x = obj.Drug_ID;

            Uri baseAddress = new Uri("https://localhost:44318/api/Subscription/" + id);
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;

                Subs s = JsonConvert.DeserializeObject<Subs>(data);
                string freq = s.RefillOccurrence;
                m = fill.PendingRefill(id, FromDate, freq);
                IEnumerable<RefillDetails> myEnumerable = (IEnumerable<RefillDetails>)m;
                return Ok(myEnumerable);


            }

            return BadRequest();
        }





        // POST api/<RefillController>
        [HttpPost("requestAdhocRefill")]
        public IActionResult requestAdhocRefill([FromBody] RefillOrderLine order)
        {
            Refill fill = new Refill();
            RefillDetails details = new RefillDetails();
            details = fill.requestAdhocRefill(order);
            if (details == null)
            {
                return BadRequest();
            }
            return Ok(details);
            ;

        }

        // PUT api/<RefillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RefillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
