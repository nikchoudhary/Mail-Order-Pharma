using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MailOrderPharmacy_Subsription.Modules;
using MailOrderPharmacy_Subsription.Repository;
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
        private ISubscription _con;

        public SubscriptionController(ISubscription con)
        {
            _con = con;
            _log4net = log4net.LogManager.GetLogger(typeof(SubscriptionController));
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
                Drug_ID=2,
                Sub_id=8,
                RefillOccurrence="Monthly",
                Member_Location="Pune"
            }
        };
        public static List<Prescription> pre = new List<Prescription>
        {
            new Prescription
            {
                drugID=1,
                MemberID=1,
                InsuranceProvider="MediBuddy"
                
                
            }

        };
        [HttpGet("{id}")]
        public IActionResult get(int id)
        {
            var item = _con.Get(id);

            return Ok(item);
        }


        // POST api/<SubscriptionController>
        [HttpPost("AddSubscription")]
        public ActionResult AddSubscription(SubscriptionDetails obj)
        {
            Subscription sub = new Subscription();
            string status = _con.AddSubscription(obj);
            //string status = sub.AddSubscription(obj);
            if (status == null)
                return BadRequest();
            return Ok(status);

             
          }
        [HttpPost("RemoveSubscription")]
        public ActionResult RemoveSubscription(SubscriptionDetails obj)
        {
            Subscription sub = new Subscription();
            string status = _con.RemoveSubscription(obj);
            //string status = sub.RemoveSubscription(obj);
            if (status == null)
                return BadRequest();
            return Ok(status);
            
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
