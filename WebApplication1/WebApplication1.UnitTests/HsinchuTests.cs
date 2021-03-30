using NUnit.Framework;

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

            _hsinchu.Calculated();

            var fee = _hsinchu.GetFee();

            Assert.That(40506, Is.EqualTo(40506).Within(0.5));
        }
    }
}