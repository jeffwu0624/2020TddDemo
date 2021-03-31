using NUnit.Framework;
using WebApplication1.Infrastructure.Logistics;
using WebApplication1.Models;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class BlackCatTests
    {
        private BlackCat _blackCat;

        [Test()]
        public void GetCompanyNameTest()
        {
            Assert.AreEqual("黑貓", _blackCat.GetCompanyName());
        }

        [SetUp]
        public void Init()
        {
            _blackCat = new BlackCat();
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _blackCat.GetFee();

            Assert.AreEqual(0, fee);
        }

        [Test()]
        public void GetFee_ShouldBe500_WhenWeightMoreThen500()
        {
            _blackCat.ShipProduct = new Product()
            {
                Weight = 500
            };

            FeeShouldBe(500);
        }

        [Test()]
        public void GetFee_ShouldBe500_WhenWeightLessThen500()
        {
            _blackCat.ShipProduct = new Product()
            {
                Weight = 20,
                Length = 10,
                Width = 10,
                Height = 10,
            };

            FeeShouldBe(300);
        }

        private void FeeShouldBe(int expected)
        {
            _blackCat.Calculated();

            Assert.AreEqual(expected, _blackCat.GetFee());
        }
    }
}