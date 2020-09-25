using MailOrderPharmacy_RefillService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MailOrderPharmacy_RefillService.Repository
{
    public class Refill : IRefill
    {
        //IRefill con;
        //public Refill(IRefill _con)
        //{
        //    con = _con;
        //}
        public static List<RefillDetails> ls = new List<RefillDetails>
        {
            new RefillDetails
            {
                RefillOrderId=1,
                Subscription_ID = 7,
                DrugID=1,
                RefillDate=new DateTime(2020,09,12),
                FromDate = new DateTime(2020, 05, 15),
                NextRefillDate=new DateTime(2020,10,08),
                Status="pending",
                Policy_ID = 001,
                Member_ID = 1,
                Location = "Delhi"
            },
            new RefillDetails
            {
                RefillOrderId=2,
                Subscription_ID = 8,
                DrugID=1,
                RefillDate=new DateTime(2020,09,12),
                FromDate = new DateTime(2020, 05, 15),
                NextRefillDate=new DateTime(2020,10,08),
                Status="clear",
                Policy_ID = 001,
                Member_ID = 02,
                Location = "Mumbai"
            }
        };
        
        public virtual dynamic viewRefillStatus(int Sub_Id)
        {
            var item = ls.Where(x => x.Subscription_ID == Sub_Id).FirstOrDefault();
            return item;
        }


        public virtual dynamic PendingRefill(int id, DateTime date)//List<RefillDetails>
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
            string freq = "";
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;

                Subs s = JsonConvert.DeserializeObject<Subs>(data);
                freq = s.RefillOccurrence;
                //m = fill.PendingRefill(id, FromDate, freq);
                //IEnumerable<RefillDetails> myEnumerable = (IEnumerable<RefillDetails>)m;
                //return Ok(myEnumerable);


            }

            //return BadRequest();





            List<RefillDetails> Pending = new List<RefillDetails>();
            if (freq == "Weekly")
            {
                int month = date.Month;
                int nxtmonth = month + 1;

                while (month != nxtmonth)
                {


                    RefillDetails refill = new RefillDetails();
                    refill.Subscription_ID = id;

                    date = date.AddDays(7);
                    refill.RefillDate = date;
                    refill.NextRefillDate = date.AddDays(7);
                    Pending.Add(refill);
                    month = date.Month;

                }
            }
            else

            {
                int year = date.Year;
                int nxtyear = year + 1;

                while (year != nxtyear)
                {


                    RefillDetails refill = new RefillDetails();
                    refill.Subscription_ID = id;

                    date = date.AddMonths(1);
                    refill.RefillDate = date;
                    refill.NextRefillDate = date.AddMonths(1);
                    Pending.Add(refill);
                    year = date.Year;

                }
            }
            return Pending;
        }

        public virtual dynamic requestAdhocRefill(RefillOrderLine order)
        {
            RefillDetails detail = ls.Where(x => x.Member_ID == order.Member_ID).FirstOrDefault();

            //string data = JsonConvert.SerializeObject(order);
            //int x = obj.Drug_ID;
            Uri baseAddress = new Uri("https://localhost:44372/api/Drugs/" + detail.DrugID);
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Drug s = JsonConvert.DeserializeObject<Drug>(data);
                if (s.drugLocation.Location == order.Location)
                {
                    return (detail);
                }
                return ("Unavailable");


            }
            return null;
        }
    }
}
