using BoDi;
using OpenQA.Selenium;
using TestSpecflowProject.Helpers;

namespace TestSpecflowProject.Hooks
{
    [Binding]
    public class Hooks
    {
        private static IObjectContainer _container;
        private static IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _container = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeRun(IObjectContainer objectContainer)
        {
            _container = objectContainer;
            _driver = WebDriverManager.InitDriver();
            _container.RegisterInstanceAs(_driver);
        }

        [AfterTestRun]
        public static void AfterRun()
        {
            _driver.Dispose();
        }
    }
}