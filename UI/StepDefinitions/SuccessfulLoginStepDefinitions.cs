using OpenQA.Selenium;
using TestSpecflowProject.PageObject;

namespace TestSpecflowProject.StepDefinitions
{
    [Binding]
    public class SuccessfulLoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly Task2 _task2;

        public SuccessfulLoginStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _task2 = new Task2(_driver);
        }

        [When(@"I enter a valid email address")]
        public void WhenIEnterAValidEmailAddress()
        {
            _task2.EnterValidEmailAddress();
        }

        [When(@"I enter a valid password")]
        public void WhenIEnterAValidPassword()
        {
            _task2.EnterValidPassword();
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            _task2.AssertThatIAmLoggedIn();
        }
    }
}