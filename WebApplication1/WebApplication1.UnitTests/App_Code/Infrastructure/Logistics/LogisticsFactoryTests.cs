using NUnit.Framework;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics.UnitTests
{
    [TestFixture()]
    public class LogisticsFactoryTests
    {
        [Test()]
        public void CreateLogistics_ShouldBeBlackCat_WhenLogisticsValueIs1()
        {
            var logistics = LogisticsFactory.CreateLogistics(new Product(), "1");

            Assert.AreEqual(new BlackCat().GetType(), logistics.GetType());
        }

        [Test()]
        public void CreateLogistics_ShouldBeHsinchu_WhenLogisticsValueIs2()
        {
            var logistics = LogisticsFactory.CreateLogistics(new Product(), "2");

            Assert.AreEqual(new Hsinchu().GetType(), logistics.GetType());
        }

        [Test()]
        public void CreateLogistics_ShouldBePostOffice_WhenLogisticsValueIs3()
        {
            var logistics = LogisticsFactory.CreateLogistics(new Product(), "3");

            Assert.AreEqual(new PostOffice().GetType(), logistics.GetType());
        }
    }
}