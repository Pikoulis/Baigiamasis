using NUnit.Framework;
using OpenQA.Selenium;

namespace spygataukuota.Page
{
    public class GoogleMapsPage : BasePage
    {
        private IWebElement CarIcon => Driver.FindElement(By.CssSelector("#omnibox-directions > div > div.widget-directions-travel-mode-switcher-container > div > div > div.adjusted-to-decreased-spacing.directions-travel-mode-selector > div:nth-child(2) > button > img"));
        private IWebElement FromImput => Driver.FindElement(By.ClassName("tactile-searchbox-input"));
        private IWebElement IagreeButton => Driver.FindElement(By.CssSelector("#introAgreeButton > span > span"));
        private IWebElement AgreementIframe => Driver.FindElement(By.ClassName("widget-consent-frame"));
        private IWebElement TotalKilometers => Driver.FindElement(By.CssSelector("#section-directions-trip-0 > div.section-directions-trip-description > div:nth-child(1) > div.section-directions-trip-numbers > div.section-directions-trip-distance.section-directions-trip-secondary-text > div"));
        public GoogleMapsPage(IWebDriver webdriver) : base(webdriver)
        {

        }
        GoogleMapsPage NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public GoogleMapsPage CheckTootalKm (string adress)
        {
            Driver.SwitchTo().Frame(AgreementIframe);
            IagreeButton.Click();
            CarIcon.Click();
            FromImput.SendKeys(adress);
            FromImput.SendKeys(Keys.Enter);
            Assert.AreEqual("108 km",TotalKilometers.Text, $"Tiketasi, kad bus 108 km, bet buvo: {TotalKilometers.Text}");
            return this;
        }
    }
}
