using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.SearchPage
{
    internal class AddMember : Login
    {
        private IWebElement lastNameTextBox => driver.FindElement(By.Id("last_name"));
        private IWebElement emailTextBox => driver.FindElement(By.Id("email"));
        private IWebElement editBillingInfoBtn => driver.FindElement(By.CssSelector(".container-fluid:nth-child(1) > .input-row > .icon"));

        [Test]
        public void AddMemberTest()
        {
            LoginTest();
            WaitForVisibleAndPerformAction(By.CssSelector(".dropdown > .hidden-xs > div"), (addMemberBtn) =>
            {
                addMemberBtn.Click();
            });
            WaitForVisibleAndPerformAction(By.Id("first_name"), (firstNameTextBox) =>
            {
                firstNameTextBox.SendKeys("Roy");
            });
            lastNameTextBox.SendKeys("Chen");
            emailTextBox.SendKeys("roy77@gmail.com");
            SelectElement selectElement = new SelectElement(driver.FindElement(By.Id("account_type")));
            Thread.Sleep(4000);
            selectElement.SelectByIndex(4);
            Thread.Sleep(1000);
            editBillingInfoBtn.Click();

            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".iti__selected-flag")).Click();
            driver.FindElement(By.Id("iti-0__item-il-preferred")).Click();
            driver.FindElement(By.CssSelector(".iti > #phone")).SendKeys("543214567");
            driver.FindElement(By.CssSelector(".row")).Click();
            driver.FindElement(By.CssSelector(".save-phone")).Click();
            driver.FindElement(By.CssSelector(".btn-orange")).Click();
            string expectedText = "Member has been saved.";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement notificationMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".notifier__notification-message")));
            string messageText = notificationMessage.Text;
            Assert.That(expectedText, Is.EqualTo(messageText), $"Add Member Failed! Expected: '{expectedText}', Actual: '{messageText}'");
            Console.WriteLine($"Add Member Test passed successfully:\n Expected: '{expectedText}', Actual: '{messageText}'");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
