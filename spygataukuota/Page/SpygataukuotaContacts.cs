using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using spygataukuota.Text;
using System.Linq;
using System.Threading;

namespace spygataukuota.Page
{
    public class SpygataukuotaContacts : BasePage
    {
        private IWebElement MapIframe => Driver.FindElement(By.CssSelector("#middle_blocks > li > div > p:nth-child(9) > iframe"));
        private IWebElement MapDirections => Driver.FindElement(By.CssSelector("#mapDiv > div > div > div:nth-child(10) > div > div > div > div.navigate > div.navigate > a"));
        private IWebElement DarboLaikas => Driver.FindElement(By.CssSelector("#block_contact_body > p:nth-child(2)"));
        private IWebElement Recaptcha => Driver.FindElement(By.CssSelector("#contact_form > div.grecaptcha"));
        public SpygataukuotaContacts(IWebDriver webdriver) : base(webdriver)
        {

        }
        public SpygataukuotaContacts InitiateGooglePage()
        {
            Actions actions = new Actions(Driver);
            GetWait().Until(ExpectedConditions.ElementToBeClickable(Recaptcha)); 
            actions.MoveToElement(DarboLaikas);
            actions.Perform();
            Driver.SwitchTo().Frame(MapIframe);
            MapDirections.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            return this;
        }
    }
}
