using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace spygataukuota.Page
{
    public class SpygataukuotaShippingSelection : BasePage
    {
        private IWebElement PurchaseInitiation => Driver.FindElement(By.XPath("//div/a[contains(@class,'offer-button fs4 fwb a0 fr')]"));
        public SpygataukuotaShippingSelection(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SpygataukuotaShippingSelection NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SpygataukuotaShippingSelection ButtonBuyPress()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(PurchaseInitiation));
            PurchaseInitiation.Click();
            return this;
        }

    }
}
