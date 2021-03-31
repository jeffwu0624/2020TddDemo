using NUnit.Framework;
using WebApplication1.Infrastructure.Logistics;
using WebApplication1.Models;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class HsinchuTests
    {
        private Hsinchu _hsinchu;

        [Test()]
        public void GetCompanyNameTest()
        {
            var companyName = _hsinchu.GetCompanyName();

            Assert.AreEqual("新竹貨運", companyName);
        }

        [SetUp]
        public void Init()
        {
            _hsinchu = new Hsinchu();
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _hsinchu.GetFee();

            Assert.AreEqual(0, fee);
        }

        [Test()]
        public void GetFee_ShouldBe_WhenSizeMoreThen100()
        {
            _hsinchu.ShipProduct = new Product()
            {
                Weight = 100,
                Length = 101,
                Width = 101,
                Height = 101
            };

            FeeShouldBe(40506);
        }

        [Test()]
        public void GetFee_ShouldBe_WhenSizeLessThen100()
        {
            _hsinchu.ShipProduct = new Product()
            {
                Weight = 100,
                Length = 10,
                Width = 10,
                Height = 10
            };

            FeeShouldBe(42);
        }

        private void FeeShouldBe(int expected)
        {
            _hsinchu.Calculated();

            Assert.That(_hsinchu.GetFee(), Is.EqualTo(expected).Within(0.9));
        }
    }
}