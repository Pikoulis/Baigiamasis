using NUnit.Framework;
using OpenQA.Selenium;
using spygataukuota.Text;

namespace spygataukuota.Page
{
    public class SpygataukuotaPasswordRecovery : BasePage
    {
        private IWebElement ForgotPass => Driver.FindElement(By.Id("reminder_email"));
        private IWebElement SendEmailButton => Driver.FindElement(By.CssSelector("#user_password_forgot > div.mt10 > a"));
        private IWebElement MessageForUser => Driver.FindElement(By.CssSelector("#middle_content > div.message.information.mt5.mb5"));
        public SpygataukuotaPasswordRecovery(IWebDriver webdriver) : base(webdriver)
        {

        }
        public SpygataukuotaPasswordRecovery EnterRecoveryMailAndSend(string email)
        {
            ForgotPass.SendKeys(email);
            SendEmailButton.Click();
            return this;
        }
        public SpygataukuotaPasswordRecovery CheckSuccessMessage()
        {
            Assert.AreEqual(AllTexts.SucessMessage1, MessageForUser.Text);
            return this;
            }

    }
}
