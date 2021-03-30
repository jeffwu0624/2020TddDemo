using NUnit.Framework;

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
    }
}