using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSpecflowProject.PageObject
{
    public class BasePage
    {
        private static IWebDriver? _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected static WebDriverWait Wait => new(_driver, TimeSpan.FromSeconds(10));

        public virtual void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static void SendText(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
            element.SendKeys(Keys.Enter);
        }
    }
}