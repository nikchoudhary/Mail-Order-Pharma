using MailOrderPharmacy_RefillService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_RefillService.Repository
{
    public interface IRefill
    {
        public dynamic viewRefillStatus(int Subscription_ID);
        //RefillDetails getRefillDuesAsOfDate(int Subscription_ID, DateTime FromDate);
        public dynamic PendingRefill(int id, DateTime date);
        public dynamic requestAdhocRefill(RefillOrderLine order);
        //public IEnumerable<RefillDetails> GetAll();
    }
}