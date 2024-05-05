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
    internal class SearchEcoDiamLogin
    {
        protected IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://core-search.ecodiam.diamonds/");
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
    }
}
