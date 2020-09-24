using MailOrderPharmacy_DrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_DrugService.Repository
{
    public class DrugLoc : IDrugLoc
    {
        public static List<DrugLocation> ls = new List<DrugLocation>
        {
            new DrugLocation
            {
                Drug_Id = 1,
                Name = "Paracetamol",
                ExpiryDate = new DateTime(2022, 08, 10),
                Available_Stock =100
            }
        };
    }
}
