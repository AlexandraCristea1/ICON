using OpenQA.Selenium;
using TestSpecflowProject.PageObject;

namespace TestSpecflowProject.StepDefinitions
{
    [Binding]
    public class UnsuccessfulLoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly Task2 _task2;
        private bool errorExists;

        public UnsuccessfulLoginStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _task2 = new Task2(_driver);
        }

        [When(@"I enter an invalid email address checking if there is an error message")]
        public void WhenIEnterAnInvalidEmailAddressCheckingIfThereIsAnErrorMessage()
        {
            errorExists = _task2.EnterInvalidEmailAddress();
        }

        [When(@"I enter a password")]
        public void WhenIEnterAPassword()
        {
            if (!errorExists)
            {
                _task2.EnterAPassword();
                _task2.AssertThatErrorMessageAfterPasswordAppears();
            }
        }

        [Then(@"an error message appears")]
        public void ThenAnErrorMessageAppears()
        {
            if (errorExists)
            {
                _task2.AssertThatErrorMessageWithoutPasswordAppears();
            }
        }
    }
}