using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using spygataukuota.Drivers;
using spygataukuota.Page;
using spygataukuota.Tools;


namespace spygataukuota.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static SpygataukuotaHomePage home;
        public static SpygataukuotaSearchResultPage search;
        public static SpygataukuotaProductPage product;
        public static SpygataukuotaShippingSelection shipp;
        public static SpygataukuotaBuyingForm form;
        public static  FacebookSpygataukuotaHome fbHome;
        public static SpygataukuotaContacts contacts;
        public static GoogleMapsPage google;
        public static SpygataukuotaPasswordRecovery recovery;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            home = new SpygataukuotaHomePage(driver);
            search = new SpygataukuotaSearchResultPage(driver);
            product = new SpygataukuotaProductPage(driver);
            shipp = new SpygataukuotaShippingSelection(driver);
            form = new SpygataukuotaBuyingForm(driver);
            fbHome = new FacebookSpygataukuotaHome(driver);
            contacts = new SpygataukuotaContacts(driver);
            google = new GoogleMapsPage(driver);
            recovery = new SpygataukuotaPasswordRecovery(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
