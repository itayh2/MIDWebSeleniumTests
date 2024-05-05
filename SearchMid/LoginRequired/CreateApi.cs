using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginRequired
{
    internal class CreateApi : SearchMidLogin
    {
        private IWebElement apiNameTextBox => driver.FindElement(By.Id("api_name"));
        private IWebElement roundShapeButton => driver.FindElement(By.CssSelector(".icon-round"));
        private IWebElement giaLabButton => driver.FindElement(By.Name("-GIA"));
        private IWebElement nextBtn => driver.FindElement(By.CssSelector(".ng-star-inserted > .col-sm-12 .btn-orange"));
        private IWebElement addAllFieldsBtn => driver.FindElement(By.CssSelector(".col-sm-4:nth-child(2) > .btn"));
        private IWebElement doneBtn => driver.FindElement(By.CssSelector(".orange-btn"));

        [Test]
        public void CreateApiTest()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement apiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-star-inserted > .item-text")));
            apiBtn.Click();

            IWebElement newApiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > ng-component > div > div > div > div > button")));
            newApiBtn.Click();

            Thread.Sleep(1000);
            apiNameTextBox.Clear();
            apiNameTextBox.SendKeys("Check json api");
            Thread.Sleep(1000);
            roundShapeButton.Click();
            giaLabButton.Click();
            Thread.Sleep(1000);
            nextBtn.Click();
            Thread.Sleep(1000);
            addAllFieldsBtn.Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, -window.innerHeight)");
            IWebElement saveApiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange:nth-child(2)")));
            saveApiBtn.Click();

            IWebElement popUp = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".title")));
            string actualText = popUp.Text;
            string expectedText = "Your API has been successfully created!";
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.Write($"Create Api Test:\n The test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");

            doneBtn.Click();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
