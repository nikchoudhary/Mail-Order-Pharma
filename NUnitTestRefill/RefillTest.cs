using MailOrderPharmacy_RefillService.Controllers;
using MailOrderPharmacy_RefillService.Models;
using MailOrderPharmacy_RefillService.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestRefill
{
    class RefillTest
    {
        //[SetUp]
        RefillDetails cust = new RefillDetails()
        {
            RefillOrderId = 1,
            Subscription_ID = 7,
            DrugID = 1,
            RefillDate = new DateTime(2020, 09, 12),
            FromDate = new DateTime(2020, 05, 15),
            NextRefillDate = new DateTime(2020, 10, 08),
            Status = "pending",
            Policy_ID = 001,
            Member_ID = 01,
            Location = "Delhi"
        };

    [Test]
    public void GetByIdPass()
    {
        Mock<Refill> mock = new Mock<Refill>();
        mock.Setup(p => p.viewRefillStatus(7)).Returns(cust);
        RefillController r = new RefillController(mock.Object);
        var data = r.RefillStatus(7) as OkObjectResult;
        Assert.AreEqual(200, data.StatusCode);
    }

    [Test]
        public void GetByIdFail()
        {
            Mock<Refill> mock = new Mock<Refill>();
            mock.Setup(p => p.viewRefillStatus(10)).Returns(cust);
            RefillController r = new RefillController(mock.Object);
            var data = r.RefillStatus(10) as OkObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }
    }
    }

