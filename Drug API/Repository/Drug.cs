using MailOrderPharmacy_DrugService.Controllers;
using MailOrderPharmacy_DrugService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOrderPharmacy_DrugService.Repository
{
    public class Drug : IDrug
    {

        public static List<DrugDetails> ls = new List<DrugDetails>
        {
            new DrugDetails
            {
                DrugId = 1,
                Name = "Paracetamol",
                Manufacturer = "Jonsons",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                //Location = "Pune",
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 1,
                    Name = "Paracetamol",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Delhi",
                    Available_Stock =100
                }

            },
             new DrugDetails
            {
                DrugId = 2,
                Name = "Ativan",
                Manufacturer = "Sun",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                //Location = "Pune",
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 2,
                    Name = "Ativan",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Mumbai",
                    Available_Stock =100
                }

            },
              new DrugDetails
            {
                DrugId = 3,
                Name = "Adderall",
                Manufacturer = "Acadia",
                ManufacturedDate = new DateTime(2020, 09, 21),
                ExpiryDate = new DateTime(2021, 07, 12),
                cost = 100.00,
                UnitPackage = 100,
                //Location = "Pune",
                Quantity = 100,
                drugLocation=new DrugLocation
                {
                    Drug_Id = 3,
                    Name = "Adderall",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location="Bangalore",
                    Available_Stock =100
                }

            }
            };
        public static List<DrugLocation> list = new List<DrugLocation>
        {
            new DrugLocation
            {
                Drug_Id = 1,
                Name = "Paracetamol",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Delhi",
                Available_Stock =100
            },
            new DrugLocation
            {
                Drug_Id = 2,
                Name = "Ativan",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Mumbai",
                Available_Stock =100
            },
            new DrugLocation
            {
                Drug_Id = 3,
                Name = "Adderall",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location="Bangalore",
                Available_Stock =100
            }
        };
        public DrugDetails searchDrugsByID(int Id)
        {
            var item = ls.Where(x => x.DrugId == Id).FirstOrDefault();
            return item;
        }
        public DrugDetails searchDrugsByName(string name)
        {
            var item = ls.Where(x => x.Name == name).FirstOrDefault();
            return item;
        }
        public IEnumerable<DrugLocation> getDispatchableDrugStock(int Id, string location)
        {
            var obj = DrugLocController.list;
            List<DrugLocation> item = new List<DrugLocation>();
            DrugDetails drug = new DrugDetails();
            var obj1 = Drug.ls;
          
            for(int i=0; i<ls.Count; i++)
            {
                if(list[i].Drug_Id ==Id && list[i].Location ==location)
                {
                    item.Add(list[i]);
                }
            }

            return item;
        }
    }
}
