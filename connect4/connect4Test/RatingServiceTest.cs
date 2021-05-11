using System;
using connect4Core.Entity;
using connect4Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace connect4Test
{
    [TestClass]
    public class RatingServiceTest
    {
        public static IRatingService CreateService()
        {
            var service = new RatingServiceEf();
            service.Reset();
            return service;
        }

        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = DateTime.Now } );
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = DateTime.Now });

            Assert.AreEqual(10,service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
        }

        [TestMethod]
        public void AddTest2()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = DateTime.Now });
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = DateTime.Now });
            service.AddRating(new Rating { Player = "martin", Stars = 5, RatedAt = DateTime.Now });

            Assert.AreEqual(5, service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
            Assert.AreEqual(-1, service.GetRating("jozi"));
        }

        [TestMethod]
        public void AverageTest1()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = DateTime.Now });
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = DateTime.Now });

            Assert.AreEqual(10, service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
            Assert.AreEqual(7.5, service.GetAverageRating());
        }

        [TestMethod]
        public void AverageTest2()
        {
            var service = CreateService();

            Assert.AreEqual(-1, service.GetRating("martin"));
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = DateTime.Now });
            service.Reset();

            Assert.AreEqual(-1, service.GetRating("martin"));
        }
    }
}