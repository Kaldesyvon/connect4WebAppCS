using System;
using connect4Core.Entity;
using connect4Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace connect4Test
{
    [TestClass]
    public class ScoreServiceTest
    {
        public static IScoreService CreateService()
        {
            var service = new ScoreServiceEf();
            service.Reset();
            return service;
        }

        [TestMethod]
        public void AddTest0()
        {
            var service = CreateService();
            
            Assert.AreEqual(0, service.GetTopScores().Count);
        }

        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();
            service.AddScore(new Score { Player = "martin", Points = 10, PlayedAt = DateTime.Now });

            Assert.AreEqual(1, service.GetTopScores().Count);
            Assert.AreEqual("martin", service.GetTopScores()[0].Player);
            Assert.AreEqual(10, service.GetTopScores()[0].Points);
        }

        [TestMethod]
        public void AddTest2()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "martin", Points = 10, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "morpheus", Points = 250, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "spongebob", Points = -10, PlayedAt = DateTime.Now });

            Assert.AreEqual(3, service.GetTopScores().Count);

            Assert.AreEqual("morpheus", service.GetTopScores()[0].Player);
            Assert.AreEqual(250, service.GetTopScores()[0].Points);

            Assert.AreEqual("martin", service.GetTopScores()[1].Player);
            Assert.AreEqual(10, service.GetTopScores()[1].Points);

            Assert.AreEqual("spongebob", service.GetTopScores()[2].Player);
            Assert.AreEqual(-10, service.GetTopScores()[2].Points);
        }

        [TestMethod]
        public void ResetTest0()
        {
            var service = CreateService();

            service.AddScore(new Score { Player = "martin", Points = 10, PlayedAt = DateTime.Now });
            service.AddScore(new Score { Player = "morpheus", Points = 250, PlayedAt = DateTime.Now });

            service.Reset();

            Assert.AreEqual(0, service.GetTopScores().Count);
        }
    }
}