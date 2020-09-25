using MailOrderPharmacy_Subsription.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace MailOrderPharmacy_Subsription.Repository
{
    public class Subscription : ISubscription
    {
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


        public virtual dynamic Get(int id)
        {
            var item = ls.Where(x => x.Sub_id == id).FirstOrDefault();
            return item;
        }
        public virtual dynamic AddSubscription(SubscriptionDetails obj)
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

                return ("Added");
            }
            return ("Unavailable");

        }

        return null;
    }
        public dynamic RemoveSubscription(SubscriptionDetails obj)
        {
            string data = JsonConvert.SerializeObject(obj);
            int x = obj.Sub_id;
            Uri baseAddress = new Uri("https://localhost:44322/api");
            HttpClient client = new HttpClient();
            client.BaseAddress = baseAddress;

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Refill/RefillStatus/" + x).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                Refill refill = JsonConvert.DeserializeObject<Refill>(data);
                if (refill.Status == "clear")
                {
                    ls.Remove(obj);
                    return ("done");
                }
                return ("Clear the Dues");
            }
            return null;
        }
}
}
