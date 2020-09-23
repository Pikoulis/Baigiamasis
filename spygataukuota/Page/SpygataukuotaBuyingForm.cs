using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using spygataukuota.Text;
using System;
using System.Text;

namespace spygataukuota.Page
{
    public class SpygataukuotaBuyingForm : BasePage
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        private IWebElement Name => Driver.FindElement(By.CssSelector("#checkout_main_form > div.grid_20.alpha.checkout-part-user > div.billing-physical > div:nth-child(1) > input"));
        private IWebElement Surname => Driver.FindElement(By.CssSelector("#checkout_main_form > div.grid_20.alpha.checkout-part-user > div.billing-physical > div:nth-child(2) > input"));
        private IWebElement Email => Driver.FindElement(By.CssSelector("#checkout_main_form > div.grid_20.alpha.checkout-part-user > div.billing-physical > div:nth-child(4) > input"));
        private IWebElement Phone => Driver.FindElement(By.CssSelector("#checkout_main_form > div.grid_20.alpha.checkout-part-user > div.billing-physical > div:nth-child(5) > input"));
        private IWebElement PaymentOption => Driver.FindElement(By.CssSelector("#checkout_main_form > div:nth-child(4) > div.checkout-part-payment > div.cart_tabs.mt10.a0.info_form_tabs.payment-tabs > div.grid_10.omega.cart_tab.fl > a"));
        private IWebElement ConditionCheckBox => Driver.FindElement(By.CssSelector("#terms"));
        private IWebElement Street => Driver.FindElement(By.Id("billingedit_street"));
        private IWebElement House => Driver.FindElement(By.Id("billingedit_house"));

        public SpygataukuotaBuyingForm(IWebDriver webdriver) : base(webdriver)
        {

        }

        public SpygataukuotaBuyingForm NavigateToPage(string PageAddress)
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SpygataukuotaBuyingForm FillForm()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 13);
            GetWait().Until(ExpectedConditions.ElementToBeClickable(Name));
            Name.SendKeys(RandomString(7, true));
            Surname.SendKeys(RandomString(7, true));
            GetWait().Until(ExpectedConditions.ElementToBeClickable(ConditionCheckBox));
            ConditionCheckBox.Click();
            Email.SendKeys(RandomString(7,false) + "@" + RandomString(4, false) + "." + RandomString(3, false));
            Phone.SendKeys(Convert.ToString(randomNumber));
            Street.SendKeys(AllTexts.Street);
            House.SendKeys(AllTexts.House);
            PaymentOption.Click();
            return this;
        }

        private string RandomString(int length, bool LT)
        {
            string pool;
            if (LT)
            {
                pool = AllTexts.LithuanianChars;
            }
            else
            {
                pool = AllTexts.Chars;
            }

            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
