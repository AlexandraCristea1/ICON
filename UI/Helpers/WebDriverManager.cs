using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestSpecflowProject.Enums;

namespace TestSpecflowProject.Helpers
{
    public class WebDriverManager
    {
        public static IWebDriver Driver { get; private set; }

        public static IWebDriver InitDriver()
        {
            Driver = SetBrowserType(BrowserEnum.CHROME);
            return Driver;
        }

        private static IWebDriver SetBrowserType(BrowserEnum browser)
        {
            switch (browser)
            {
                case BrowserEnum.CHROME: return new ChromeDriver(GetChromeOptions());
                default: throw new Exception("Browser is not configured");
            }
        }

        private static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--incognito");

            return chromeOptions;
        }
    }
}