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
        Mock<IRefill> mock = new Mock<IRefill>();
        mock.Setup(p => p.viewRefillStatus(7)).Returns(cust);
        RefillController r = new RefillController(mock.Object);
        var data = r.RefillStatus(7) as OkObjectResult;
        Assert.AreEqual(200, data.StatusCode);
    }

    [Test]
        public void GetByIdFail()
        {
            try
            {

                RefillDetails obj = new RefillDetails();
                Mock<IRefill> mock = new Mock<IRefill>();
                mock.Setup(p => p.viewRefillStatus(10)).Returns(null);
                RefillController r = new RefillController(mock.Object);
                var data = r.RefillStatus(10) as OkObjectResult;
                Assert.AreEqual(200, data.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
        List<RefillDetails> ls = new List<RefillDetails>()
        {
            new RefillDetails
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
            }
        };
        [Test]
        public void RefillDuesPass()
        {
            Mock<IRefill> mock = new Mock<IRefill>();
            mock.Setup(p => p.PendingRefill(7, new DateTime(2020, 06, 12))).Returns(ls);
            
            RefillController obj = new RefillController(mock.Object);
            var res = obj.RefillDueAsOfDate(7, new DateTime(2020, 06, 12)) as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void RefillDuesFail()
        {
            try
            {
                Mock<IRefill> mock = new Mock<IRefill>();
                mock.Setup(p => p.PendingRefill(7, new DateTime(2020, 06, 12))).Returns(null);

                RefillController obj = new RefillController(mock.Object);
                var res = obj.RefillDueAsOfDate(7, new DateTime(2020, 06, 12)) as OkObjectResult;
                Assert.AreEqual(200, res.StatusCode);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
    }

