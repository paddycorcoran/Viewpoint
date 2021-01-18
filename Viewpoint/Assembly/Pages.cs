using SeleniumExtras.PageObjects;
using Viewpoint;
using Viewpoint.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumProject
{
    //Class to handle the page mapping
    public static class Pages
    {
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browsers.getDriver, page);
            return page;
        }
        public static LandingPage landingPage
        {
            get { return getPages<LandingPage>(); }
        }
    }
}
