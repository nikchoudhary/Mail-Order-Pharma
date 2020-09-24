//using MailOrderPharmacy_Subsription.Modules;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using System.Net.Http;

//namespace MailOrderPharmacy_Subsription.Repository
//{
//    public class Subscription:ISubscription
//    {
//        public static List<SubscriptionDetails> ls = new List<SubscriptionDetails>
//        {
//            new SubscriptionDetails
//            {
//                Drug_ID=101,
//                date=new DateTime(2020,06,12),
//                Member_Location="Pune"
//            }
//        };

//        [HttpPost]
//        public ActionResult AddSubscription(SubscriptionDetails obj)
//        {
//            string data = JsonConvert.SerializeObject(obj);
//            //int x = obj.Drug_ID;
//            Uri baseAddress = new Uri("https://localhost:port/api");
//            HttpClient client = new HttpClient();
//            client.BaseAddress = baseAddress;
//            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "Token");
//            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Drugs" + obj).Result;
//            if (response.IsSuccessStatusCode)
//            {
//                return Ok(obj);
//            }
//            return BadRequest();
//        }
//    }
//    }
//}
