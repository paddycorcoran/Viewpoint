using NUnit.Framework;
using OpenQA.Selenium;
using System;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using How = SeleniumExtras.PageObjects.How;
using OpenQA.Selenium.Interactions;


namespace Viewpoint.PageObjects
{ 
    public class LandingPage
    {
        //Locators
                
        [FindsBy(How = How.Id, Using = "Belgium-cb-label-CountryFilter")]
        public IWebElement CountryFilter { get; set; }

        [FindsBy(How = How.Id, Using = "btn-update")]
        private IWebElement UpdateButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[2]/table/tbody/tr")]
        public IWebElement CountryRows { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[3]/span[1]/span")]
        public IWebElement ItemsPerPage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[3]/span[1]/span/span")]
        public IWebElement ItemsDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "grid_active_cell")]
        private IWebElement CountryCol { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[3]/a[3]")]
        public IWebElement nextPageButton { get; set; }

        [FindsBy(How = How.XPath, Using = "#grid > div.k-grid-content.k-auto-scrollable > table > tbody > tr:nth-child(59) > td:nth-child(1) > a")]
        public IWebElement ABlizzInc { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='grid']/div[3]/a[5]/span")]
        public IWebElement RefreshButton { get; set; }

        [FindsBy(How = How.Id, Using = "detail-issuer-name")]
        private IWebElement CompanyName { get; set; }

        


        //Actions
        public void VerifyLandingPageLoadedOK()
        {
            //
            Assert.IsTrue(CountryFilter.ControlDisplayed());
            Assert.IsTrue(Browsers.Title.Equals("Sample Disclosure"));
        }
        public void ValidateCountryFilterAndSearchText(string searchText)
        {
            Assert.IsTrue(CountryFilter.Displayed);
            Assert.IsTrue(CountryFilter.Enabled);
            Assert.IsTrue(CountryFilter.ElementlIsClickable());
            CountryFilter.Click();
        }

        public void ValidateAndSelectUpdateButton()
        {
            Assert.IsTrue(CountryFilter.ControlDisplayed());
            Assert.IsTrue(UpdateButton.Displayed);
            Assert.IsTrue(UpdateButton.Enabled);
            Assert.IsTrue(UpdateButton.ElementlIsClickable());
            UpdateButton.Click();
            
        }

        public void ValidateCountryListFromSearch()
        
        {
            String text = "";
            IWebDriver driver = Browsers.getDriver;
            Browsers.WaitUntilElementExists(By.XPath("//*[@id='grid']/div[3]/span[1]/span"));
        
            //Set Items Per Page to 150
            OpenQA.Selenium.Interactions.Actions builder = new Actions(driver);
            builder.Click(ItemsPerPage).Build().Perform();
            builder.SendKeys("150");
            builder.Click(ItemsPerPage).Build().Perform();

            //verify next page is disabled incase result > 150
            Assert.IsTrue(Browsers.hasClass(nextPageButton, "disabled"));
            
            //Count number of rows returned from Belgium search
            int iRowsCount = driver.FindElements(By.XPath("//*[@id='grid']/div[2]/table/tbody/tr")).Count;

            //Iterate rows and Verify Belgium is in Country field for each
            for (int i = 1; i < iRowsCount; i++)
            {
                text = driver.FindElement(By.XPath("//*[@id='grid']/div[2]/table/tbody/tr[" + iRowsCount + "]/td[4]")).Text;
                Assert.AreEqual(text, "Belgium");
            
            }
        }

        public void ValidateActivationBlizzardIncCompany()
        {
            IWebDriver driver = Browsers.getDriver;
            Browsers.WaitUntilElementExists(By.XPath("//*[@id='grid']/div[3]/span[1]/span"));
            Browsers.WaitForReady();
            //Set Items Per Page to 150
            OpenQA.Selenium.Interactions.Actions builder = new Actions(driver);
            builder.Click(ItemsPerPage).Build().Perform();
            builder.SendKeys("150");
            builder.Click(ItemsPerPage).Build().Perform();
            RefreshButton.Click();
            Browsers.WaitForReady();

            //Assert.IsTrue(ABlizzInc.Enabled);
            Assert.IsTrue(ABlizzInc.ElementlIsClickable());
            Actions actions = new Actions(driver);
            actions.MoveToElement(
            driver.FindElement(By.CssSelector("#grid > div.k-grid-content.k-auto-scrollable > table > tbody > tr:nth-child(59) > td:nth-child(1) > a"))).Click().Perform();
            Browsers.WaitForReady();
            Assert.AreEqual(CompanyName.Text, "Activision Blizzard Inc");

        }
    }
}