using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace Viewpoint
{
    public static class Browsers
    {
        private static IWebDriver webDriver;
        private static string baseURL = "https://viewpoint.glasslewis.com/WD/?siteId=DemoClient";
        private static string browser = "Chrome";
        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "IE":
                    webDriver = new OpenQA.Selenium.IE.InternetExplorerDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
            Goto(baseURL);
        }

        //Helper methods
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public static void Goto(string url)
        {
            webDriver.Url = url;
        }
        public static void Close()
        {
            webDriver.Quit();
        }
        public static bool ControlDisplayed(this IWebElement element, bool displayed = true, uint timeoutInSeconds = 60)
        {
            var wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(timeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(System.Exception));
            return wait.Until(drv =>
            {
                if (!displayed && !element.Displayed || displayed && element.Displayed)
                {
                    return true;
                }
                return false;
            });
        }
        public static bool ElementlIsClickable(this IWebElement element, uint timeoutInSeconds = 60, bool displayed = true)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv =>
                {
                    if (SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element) != null)
                        return true;
                    return false;
                });
            }
            catch
            {
                return false;
            }
        }
        public static IWebElement WaitUntilElementExists(By elementLocator, int timeout = 100)
        {
            try
            {
                var wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' failed to load");
                throw;
            }
        }

        public static bool hasClass(IWebElement element, String theClass)
        {
            return (" " + element.GetAttribute("class") + " ").Contains(theClass);
        }


        public static void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, System.TimeSpan.FromSeconds(10));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return jQuery.active == 0"));
        }

    }
}