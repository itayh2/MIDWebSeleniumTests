using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace MIDWebTests.MyMid
{
    public class Login
    {
        protected IWebDriver driver;
        private IWebElement passwordInput => driver.FindElement(By.Id("1-password"));
        private IWebElement submitBtn => driver.FindElement(By.Id("1-submit"));
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://core-mymid.middiamonds.com/");
        }
        public void LoginTest()
        {
            string initialWindowHandle = driver.CurrentWindowHandle;
            WaitForVisibleAndPerformAction(By.Id("1-email"), (emailInput) =>
            {
                emailInput.SendKeys("itay@middiamonds.com");
            });
            passwordInput.SendKeys("Itay2023!");
            submitBtn.Click();
            driver.SwitchTo().Window(initialWindowHandle);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".light")));
            WaitForVisibleAndAssertText(By.CssSelector(".light"), "Hi Itay Hasid");
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