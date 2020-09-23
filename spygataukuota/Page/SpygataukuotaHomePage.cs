using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using spygataukuota.Text;

namespace spygataukuota.Page
{
    public class SpygataukuotaHomePage : BasePage
    {
        private const string PageAddress = "https://www.spygataukuota.lt/";

        private IWebElement CookieAgrrementText => Driver.FindElement(By.Id("cookieconsent:desc"));
        private IWebElement CookieAgrrementBoxButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"));
        private IWebElement SearchForGoodsImput => Driver.FindElement(By.Id("main-search-input"));
        private IWebElement FacebookIcon => Driver.FindElement(By.ClassName("fb"));
        private IWebElement Contacts => Driver.FindElement(By.CssSelector("#menu_footer > li.fl.footer-level1.footer-level1-last"));
        private IWebElement Login => Driver.FindElement(By.Id("login_on"));
        private IWebElement ForgotPass => Driver.FindElement(By.Id("forgot"));
        public SpygataukuotaHomePage(IWebDriver webdriver) : base(webdriver)
        { }

        public SpygataukuotaHomePage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SpygataukuotaHomePage CheckCookieAgreementText(string textToCheck)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(CookieAgrrementBoxButton));
            Assert.AreEqual(textToCheck, CookieAgrrementText.Text, $"Tikejomes {textToCheck} ,bet buvo: {CookieAgrrementText.Text}");
            return this;
        }
        public SpygataukuotaHomePage AgreeWithCookie()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(CookieAgrrementBoxButton));
            CookieAgrrementBoxButton.Click();
            return this;
        }

        public SpygataukuotaHomePage AddToBasket(string product)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(SearchForGoodsImput));
            SearchForGoodsImput.SendKeys(product);
            SearchForGoodsImput.SendKeys(Keys.Enter);
            return this;
        }
        public SpygataukuotaHomePage FacebookIconClick()
        {
            FacebookIcon.Click();
            string Facebook = Driver.WindowHandles[1];
            Assert.IsTrue(!string.IsNullOrEmpty(Facebook));
            Assert.AreEqual(Driver.SwitchTo().Window(Facebook).Url, AllTexts.FBurl);
            return this;
        }
        public SpygataukuotaHomePage ClickContacts()
        {
            Contacts.Click();
            return this;
        }
        public SpygataukuotaHomePage InitiateForgotPasswordForm()
        {
            GetWait(15).Until(ExpectedConditions.ElementToBeClickable(Login));
            Login.Click();
            ForgotPass.Click();
            return this;
        }
    }
}
