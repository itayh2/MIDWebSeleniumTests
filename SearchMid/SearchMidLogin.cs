using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid
{
    internal class SearchMidLogin
    {
        protected IWebDriver driver;
        private IWebElement loginBtn => driver.FindElement(By.CssSelector(".light"));
        private IWebElement passwordInput => driver.FindElement(By.Id("1-password"));
        private IWebElement submitBtn => driver.FindElement(By.CssSelector(".auth0-label-submit"));
        private IWebElement userIcon => driver.FindElement(By.CssSelector(".ng-tns-c20-0 > .icon-user"));
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://core-search.middiamonds.com/");
        }

        public void LoginTest(string email, string password)
        {
            string initialWindowHandle = driver.CurrentWindowHandle;
            loginBtn.Click();
            string? newWindowHandle = WaitForNewWindowHandle(20);
            driver.SwitchTo().Window(newWindowHandle);
            WaitForVisibleAndPerformAction(By.Id("1-email"), (emailInput) =>
            {
                emailInput.SendKeys(email);
            });
            passwordInput.SendKeys(password);
            submitBtn.Click();
            driver.SwitchTo().Window(initialWindowHandle);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-tns-c20-0 > .icon-user")));
            Thread.Sleep(5000);
            userIcon.Click();
            WaitForVisibleAndAssertText(By.CssSelector(".bold-text"), "Hi Itay Hasid!");
        }
        protected string? WaitForNewWindowHandle(int timeout)
        {
            string? currentWindowHandle = driver.CurrentWindowHandle;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            return wait.Until(win => driver.WindowHandles.FirstOrDefault(handle => handle != currentWindowHandle));
        }
        protected void WaitForVisibleAndPerformAction(By locator, Action<IWebElement> action, int timeoutInSeconds = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

            action(element);
        }
        public void WaitForVisibleAndAssertText(By locator, string expectedText, int timeoutInSeconds = 20)
        {
            WaitForVisibleAndPerformAction(locator, (element) =>
            {
                string actualText = element.Text;
                if (actualText != expectedText)
                {
                    Assert.Fail($"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
                }
                else
                {
                    Console.WriteLine($"Login Test:\nThe test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");
                }
            }, timeoutInSeconds);
        }
        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", element);
            Thread.Sleep(500);
        }
    }
}
