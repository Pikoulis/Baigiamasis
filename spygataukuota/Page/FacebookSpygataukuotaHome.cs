using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using spygataukuota.Text;

namespace spygataukuota.Page
{
    public class FacebookSpygataukuotaHome : BasePage
    {
        private IWebElement MeniuAbout => Driver.FindElement(By.CssSelector("#u_0_i > div:nth-child(6) > a > span._2yav"));
        private IWebElement TotalLikes => Driver.FindElement(By.Id("PagesLikesCountDOMID"));
        private IWebElement LinkToWebsite => Driver.FindElement(By.Id("u_jsonp_2_1"));
        public FacebookSpygataukuotaHome(IWebDriver webdriver) : base(webdriver)
        {

        }
        public FacebookSpygataukuotaHome NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public FacebookSpygataukuotaHome NavigateToMeniuAbout()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[0]).Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            GetWait().Until(ExpectedConditions.ElementToBeClickable(MeniuAbout));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(TotalLikes);
            actions.Perform();
            MeniuAbout.Click();
            return this;
        }
        public FacebookSpygataukuotaHome NavigateToWesiteAndCloseTab()
        {
            LinkToWebsite.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]).Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            string Spygataukuota = Driver.WindowHandles[0];
            Assert.IsTrue(!string.IsNullOrEmpty(Spygataukuota));
            Assert.AreEqual(Driver.SwitchTo().Window(Spygataukuota).Url, AllTexts.SpygataukuotaUrl);
            return this;
        }
    }
}
