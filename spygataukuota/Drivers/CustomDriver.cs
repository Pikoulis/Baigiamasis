using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;

namespace spygataukuota.Drivers
{
    public class CustomDriver
    {
        public static IWebDriver GetChromeDriver()
        {
            return GetDriver(Browsers.Chrome);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            return GetDriver(Browsers.Firefox);
        }
        public static IWebDriver GetChromeDriverWithOptions()
        {
            return GetDriver(Browsers.ChromeProfile);
        }
        private static IWebDriver GetDriver(Browsers browserName)
        {
            IWebDriver driver = null;

            switch (browserName)
            {
                case Browsers.Firefox:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case Browsers.Chrome:

                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;

                case Browsers.ChromeProfile:
                    driver = GetChromeWithOptions();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;

        }
        private static IWebDriver GetChromeWithOptions()
        {
            ChromeOptions options = new ChromeOptions();
            string userDataPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            string userDataPathFolder = Path.Combine(userDataPath, "User Data");
            options.AddArgument($"user-data-dir={userDataPathFolder}");
            options.AddArgument("disable-infobars");
            options.AddArgument("--profile-directory=Default");
            return new ChromeDriver(options);
        }
    }
}
