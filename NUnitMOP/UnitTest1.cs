using NUnit.Framework;
using MailOrderPharmacy_DrugService.Repository;
using MailOrderPharmacy_DrugService.Controllers;
using MailOrderPharmacy_DrugService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System;

namespace NunitMOP
{
    public class UnitTest1
    {

        // [SetUp]
        DrugDetails pcm = new DrugDetails()

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
            drugLocation = new DrugLocation
            {
                Drug_Id = 1,
                Name = "Paracetamol",
                ExpiryDate = new DateTime(2022, 08, 10),
                Location = "Delhi",
                Available_Stock = 100
            }
        };

        List<DrugLocation> claimList = new List<DrugLocation>();
        [SetUp]
        public void Setup()
        {
            claimList = new List<DrugLocation>
            {
                new DrugLocation()
                {
                    Drug_Id = 1,
                    Name = "Paracetamol",
                    ExpiryDate = new DateTime(2022, 08, 10),
                    Location = "Delhi",
                    Available_Stock = 100
                }
            };
            }

             

        

        
    [Test]
        public void Test1()
        {
            Mock<Drug> mock = new Mock<Drug>();
            mock.Setup(p => p.searchDrugsByID(1)).Returns(pcm);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetails(1) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        [Test]
        public void Test2()
        {
            var mock = new Mock<Drug>();
            mock.Setup(p => p.searchDrugsByName("Paracetamol")).Returns(pcm);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDrugDetailByName("Paracetamol") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        [Test]
        public void Test3()
        {
            var mock = new Mock<Drug>();
            mock.Setup(p => p.getDispatchableDrugStock(1, "Delhi")).Returns(claimList);
            DrugsController con = new DrugsController(mock.Object);
            var data = con.GetDispatchableDrugStock(1, "Delhi") as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }



    }

    }
