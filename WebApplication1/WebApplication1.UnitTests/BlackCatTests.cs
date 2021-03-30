using NUnit.Framework;

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
        public void GetFee_ShoudBeZero_WhenInit()
        {
            var fee = _blackCat.GetFee();

            Assert.AreEqual(0, fee);
        }

        [Test()]
        public void GetFee_ShoudBe500_WhenWeightMoreThen500()
        {
            _blackCat.ShipProduct = new Product()
            {
                Weight = 500
            };

            _blackCat.Calculated();

            var fee = _blackCat.GetFee();

            Assert.AreEqual(500, fee);
        }
    }
}