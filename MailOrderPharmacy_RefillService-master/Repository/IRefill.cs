using MailOrderPharmacy_RefillService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_RefillService.Repository
{
    public interface IRefill
    {
        public RefillDetails viewRefillStatus(int Subscription_ID);
        //RefillDetails getRefillDuesAsOfDate(int Subscription_ID, DateTime FromDate);
        public List<RefillDetails> PendingRefill(int id, DateTime date, string freq);
        public dynamic requestAdhocRefill(RefillOrderLine order);
        //public IEnumerable<RefillDetails> GetAll();
    }
}