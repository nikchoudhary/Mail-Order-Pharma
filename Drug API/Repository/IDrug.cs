using MailOrderPharmacy_DrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_DrugService.Repository
{
    public interface IDrug
    {
        public DrugDetails searchDrugsByID(int DrugId);
        public DrugDetails searchDrugsByName(string Name);

        public IEnumerable<DrugLocation> getDispatchableDrugStock(int DrugId, string Location);
    }
}
