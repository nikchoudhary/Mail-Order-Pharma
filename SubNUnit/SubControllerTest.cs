using NUnit.Framework;
using MailOrderPharmacy_Subsription.Repository;
using MailOrderPharmacy_Subsription.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System;
using MailOrderPharmacy_Subsription.Modules;

namespace SubNUnit
{
    public class SubControllerTest
    {

        // [SetUp]
        SubscriptionDetails db = new SubscriptionDetails()

        {
            
                Drug_ID=2,
                Sub_id=8,
                RefillOccurrence="Monthly",
                Member_Location="Pune"
            
        };



        [Test]
        public void Test1()
        {
            Mock<Subscription> mock = new Mock<Subscription>();
            mock.Setup(p => p.Get(2)).Returns(db);
            SubscriptionController con = new SubscriptionController(mock.Object);
            var data = con.get(2) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        [Test]
        public void Test2()
        {
            Mock<ISubscription> acr = new Mock<ISubscription>();
            acr.Setup(p => p.AddSubscription(db)).Returns("Added");
            SubscriptionController contr = new SubscriptionController(acr.Object);
            var data = contr.AddSubscription(db) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        [Test]
        public void Test3()
        {
            Mock<ISubscription> acr = new Mock<ISubscription>();
            acr.Setup(p => p.RemoveSubscription(db)).Returns("done");
            SubscriptionController contr = new SubscriptionController(acr.Object);
            var data = contr.RemoveSubscription(db) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }






    }

}
