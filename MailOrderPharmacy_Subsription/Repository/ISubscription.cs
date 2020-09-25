using MailOrderPharmacy_Subsription.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_Subsription.Repository
{
    public interface ISubscription
    {
        public dynamic Get(int id);
        public dynamic AddSubscription(SubscriptionDetails obj);
        public dynamic RemoveSubscription(SubscriptionDetails obj);
    }
}
