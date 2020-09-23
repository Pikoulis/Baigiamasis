using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;

namespace spygataukuota.Page
{
    public class SpygataukuotaProductPage : BasePage
    {
        private IWebElement Tocard => Driver.FindElement(By.XPath("//div/a[contains(@class,'addCart btn1 a0 fl ml10 fs3')]"));

        public SpygataukuotaProductPage(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SpygataukuotaProductPage NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SpygataukuotaProductPage ToCart()
        {

            GetWait().Until(ExpectedConditions.ElementToBeClickable(Tocard));
            Tocard.Click();
            return this;
        }
    }
}
