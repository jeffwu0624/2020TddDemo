using NUnit.Framework;
using WebApplication1.Infrastructure.Logistics;
using WebApplication1.Models;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class PostOfficeTests
    {
        private PostOffice _postOffice;


        [Test()]
        public void GetCompanyName_Test()
        {
            var companyName = _postOffice.GetCompanyName();

            Assert.AreEqual("郵局",companyName);
        }

        [SetUp]
        public void Init()
        {
            _postOffice = new PostOffice();
        }

        [Test()]
        public void GetFee_ShouldBeZero_WhenInit()
        {
            var fee = _postOffice.GetFee();

            Assert.AreEqual(0, fee);
        }

        [Test]
        public void GetFee_ShouldBe_WhenWeightMoreThenSize()
        {
            _postOffice.ShipProduct = new Product()
            {
                Weight = 10,
                Length = 10,
                Width = 10,
                Height = 10
            };

            FeeShouldBe(38);
        }

        [Test]
        public void GetFee_ShouldBe_WhenWeightLessThenSize()
        {
            _postOffice.ShipProduct = new Product()
            {
                Weight = 10,
                Length = 1000,
                Width = 1000,
                Height = 1000
            };

            FeeShouldBe(180);
        }

        private void FeeShouldBe(int expected)
        {
            _postOffice.Calculated();

            var fee = _postOffice.GetFee();

            Assert.That(fee, Is.EqualTo(expected).Within(0.9));
        }
    }
}