using OpenQA.Selenium;
using TestSpecflowProject.PageObject;

namespace TestSpecflowProject.StepDefinitions
{
    [Binding]
    internal class CommonStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly Task2 _task2;

        public CommonStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _task2 = new Task2(_driver);
        }

        [Given(@"^I am on (.*)")]
        public void GivenIAmOn(string url)
        {
            _task2.NavigateToPage(url);
        }

        [Given(@"I accept all cookies")]
        public void GivenIAcceptAllCookies()
        {
            _task2.AcceptAllCookiesModalWindow();
        }

        [Given(@"I click on Log In button")]
        public void GivenIClickOn()
        {
            _task2.ClickOnLogInButton();
        }
    }
}