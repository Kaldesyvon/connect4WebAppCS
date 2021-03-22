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
            return new RatingServiceFile();
        }

        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = new DateTime() } );
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = new DateTime() });

            Assert.AreEqual(10,service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
        }

        [TestMethod]
        public void AddTest2()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = new DateTime() });
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = new DateTime() });
            service.AddRating(new Rating { Player = "martin", Stars = 5, RatedAt = new DateTime() });

            Assert.AreEqual(5, service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
            Assert.AreEqual(-1, service.GetRating("jozi"));
        }

        [TestMethod]
        public void AverageTest()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = new DateTime() });
            service.AddRating(new Rating { Player = "obi-wan", Stars = 5, RatedAt = new DateTime() });

            Assert.AreEqual(10, service.GetRating("martin"));
            Assert.AreEqual(5, service.GetRating("obi-wan"));
            Assert.AreEqual(7.5, service.GetAverageRating());
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddRating(new Rating { Player = "martin", Stars = 10, RatedAt = new DateTime() });
            service.Reset();

            Assert.AreEqual(-1, service.GetRating("martin"));
        }
    }
}
