using NUnit.Framework;
using SeleniumProject;
namespace Viewpoint
{
    [TestFixture]
    public class UITests
    {
        [SetUp]
        public void StartUpTest()
        {
            Browsers.Init();
        }
        [TearDown]
        public void EndTest()
        {
           Browsers.Close();
        }
        [Test]
        public void Story1()
        {
            Pages.landingPage.VerifyLandingPageLoadedOK();
            Pages.landingPage.ValidateCountryFilterAndSearchText("Belgium");
            Pages.landingPage.ValidateAndSelectUpdateButton();
            Pages.landingPage.ValidateCountryListFromSearch();

        }
        [Test]
        public void Story2()
        {
            Pages.landingPage.VerifyLandingPageLoadedOK();
            Pages.landingPage.ValidateActivationBlizzardIncCompany();
        }
    }
}