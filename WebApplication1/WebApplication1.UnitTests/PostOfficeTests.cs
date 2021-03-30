using NUnit.Framework;

namespace WebApplication1.UnitTests
{
    [TestFixture()]
    public class PostOfficeTests
    {
        

        [Test()]
        public void GetCompanyName_Test()
        {
            var postOffice = new PostOffice();

            var companyName = postOffice.GetCompanyName();

            Assert.AreEqual("郵局",companyName);
        }

        [Test()]
        public void GetFeeTest()
        {
            Assert.Fail();
        }
    }
}