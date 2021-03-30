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
            
        }
    }
}