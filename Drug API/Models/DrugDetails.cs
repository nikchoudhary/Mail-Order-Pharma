using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_DrugService.Models
{
    public class DrugDetails
    {
        public int DrugId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime ExpiryDate {get; set;}
        public double cost { get; set; }
        public int UnitPackage { get; set; }
        //public string Location { get; set; }
        public double Quantity { get; set; }//drug details(ID, location, quantity)
        public DrugLocation drugLocation { get; set; }

        




    }
}
