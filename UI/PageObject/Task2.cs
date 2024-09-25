using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSpecflowProject.PageObject
{
    internal class Task2 : BasePage
    {
        private readonly IWebDriver _driver;

        public Task2(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Locators
        private IWebElement LogInBtn => _driver.FindElement(By.CssSelector(".rich-wrapper--hero-vertical a[target=\"_self\"]"));
        private IWebElement EmailField => _driver.FindElement(By.Id("email"));
        private IWebElement PasswordField => _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4 > div > input"));
        private IWebElement ErrorMessageWithoutPassword => _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4 > span"));
        private IWebElement ErrorMessageWithPassword => _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4 > div > span"));
        private IWebElement SignInLabel => _driver.FindElement(By.XPath("//h1[text()='Sign in']"));
        private IWebElement AcceptAllCookiesBtn => _driver.FindElement(By.CssSelector("button.rounded-md.bg-accent.text-colors-eggshell"));
        private IWebElement SearchField => _driver.FindElement(By.Id("qa-SEARCH_BAR_INITIAL"));
        private IWebElement NoteBtn => _driver.FindElement(By.CssSelector("button.sDRElR8ZlYFOGDwDIUvA.zGOqamHc_vj4fK3IG5VE.HUWoDG8e8KhEOGqVocpC"));
        #endregion

        #region Clicking
        public void ClickOnLogInButton()
        {
            LogInBtn.Click();
            Wait.Until(driver => SignInLabel.Displayed);
        }
        #endregion

        #region Assertions
        public void AssertThatErrorMessageWithoutPasswordAppears()
        {
            Wait.Until(driver => ErrorMessageWithoutPassword.Displayed);
            Assert.That(ErrorMessageWithoutPassword.Displayed);
        }

        public void AssertThatErrorMessageAfterPasswordAppears()
        {
            Wait.Until(driver => ErrorMessageWithPassword.Displayed);
            Assert.That(ErrorMessageWithPassword.Displayed);
        }

        public void AssertThatIAmLoggedIn()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(30);

            fluentWait.Until(driver =>
            {
                var noteBtn = _driver.FindElement(By.CssSelector("div._znCG6SJjdDLmBc7V5HD")).FindElements(By.TagName("div")).Count > 1;
                return noteBtn;
            });

            Assert.That(SearchField.Displayed);
        }
        #endregion

        #region Insert
        public bool EnterInvalidEmailAddress()
        {
            SendText(EmailField, "alexandra.cristea79@yahoo.com");
            WaitUntilPasswordFieldOrErrorAppear();

            var containsPasswordInput = _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4")).FindElements(By.TagName("div")).Count > 1;

            if (containsPasswordInput)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void EnterValidEmailAddress()
        {
            SendText(EmailField, "alexandracristea79@yahoo.com");
            WaitUntilPasswordFieldOrErrorAppear();
        }

        public void EnterAPassword()
        {
            SendText(PasswordField, "rtgfvdb");
        }

        public void EnterValidPassword()
        {
            SendText(PasswordField, "PaSsWoRdEv3rN0t#");
        }
        #endregion

        #region Others
        public void AcceptAllCookiesModalWindow()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);

            fluentWait.Until(driver =>
            {
                return _driver.FindElements(By.CssSelector("#__next > div > div > div > div.relative.flex.flex-col.space-y-2.px-3.pt-2.after\\:absolute.after\\:-top-8.after\\:left-0.after\\:h-8.after\\:w-full.after\\:bg-gradient-to-t.after\\:from-white.after\\:to-transparent.sm\\:flex-row.sm\\:space-y-0.sm\\:space-x-2.sm\\:px-5 > button.rounded-md.border.border-black.text-center.transition-all.ease-in-out.hover\\:-translate-y-px.hover\\:shadow-button.min-w-\\[154px\\].py-2.px-10.bg-accent.text-colors-eggshell.w-full.px-2.undefined")).Count > 0;
            });

            AcceptAllCookiesBtn.Click();
        }

        public void WaitUntilPasswordFieldOrErrorAppear()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);

            fluentWait.Until(driver =>
            {
                var containsPasswordInput = _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4")).FindElements(By.TagName("div")).Count > 1;
                var containsError = _driver.FindElement(By.CssSelector("form > div.flex.flex-col.space-y-4")).FindElements(By.TagName("span")).Count > 1;
                return containsPasswordInput || containsError;
            });
        }
        #endregion
    }
}