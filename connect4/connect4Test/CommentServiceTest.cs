using System;
using connect4Core.Entity;
using connect4Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace connect4Test
{
    [TestClass]
    public class CommentServiceTest
    {
        private static ICommentService CreateService()
        {
            var service = new CommentServiceEF();
            service.Reset();
            return service;
        }

        [TestMethod]
        public void AddTest1()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "martin", Feedback = "najlepsia hra na svete", CommentedAt = new DateTime() });

            Assert.AreEqual(1, service.GetComments().Count);
        }

        [TestMethod]
        public void AddTest2()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "martin", Feedback = "keby som dostal keksik za vyhru, mal by som jeden keksik", CommentedAt = DateTime.Now });
            service.AddComment(new Comment { Player = "luna", Feedback = "meow", CommentedAt = DateTime.Now });
            service.AddComment(new Comment { Player = "hamlet", Feedback = "to be or not to be", CommentedAt = DateTime.Now });
            service.AddComment(new Comment { Player = "barborka", Feedback = "mam viac keksikov ako martin", CommentedAt = DateTime.Now });

            Assert.AreEqual(4, service.GetComments().Count);

            Assert.AreEqual("barborka", service.GetComments()[0].Player);
            Assert.AreEqual("mam viac keksikov ako martin", service.GetComments()[0].Feedback);

            Assert.AreEqual("hamlet", service.GetComments()[1].Player);
            Assert.AreEqual("to be or not to be", service.GetComments()[1].Feedback);

            Assert.AreEqual("luna", service.GetComments()[2].Player);
            Assert.AreEqual("meow", service.GetComments()[2].Feedback);

            Assert.AreEqual("martin", service.GetComments()[3].Player);
            Assert.AreEqual("keby som dostal keksik za vyhru, mal by som jeden keksik", service.GetComments()[3].Feedback);
        }

        [TestMethod]
        public void ResetTest()
        {
            var service = CreateService();

            service.AddComment(new Comment { Player = "dony", Feedback = "hau", CommentedAt = DateTime.Now });
            service.Reset();

            Assert.AreEqual(0, service.GetComments().Count);
        }
    }
}
