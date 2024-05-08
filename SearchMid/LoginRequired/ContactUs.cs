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
    internal class ContactUs : SearchMidLogin
    {
        private IWebElement phoneTextBox => driver.FindElement(By.Id("phone"));
        private IWebElement subjectTextBox => driver.FindElement(By.Id("subject"));
        private IWebElement messgeTextBox => driver.FindElement(By.CssSelector(".form-group:nth-child(7) > .ng-untouched"));
        private IWebElement sendDetailsBtn => driver.FindElement(By.CssSelector(".send-btn:nth-child(8) > span"));
        private IWebElement gotItBtn => driver.FindElement(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > contact > modal > div > div > div > div > div > div > button"));
        
        [Test]
        public void SendInquiryTest()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement contactUsBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-contact")));
            contactUsBtn.Click();

            phoneTextBox.SendKeys("0542887133");
            subjectTextBox.SendKeys("Test Please ignore!!!");
            messgeTextBox.SendKeys("Hi, this is a testing");
            sendDetailsBtn.Click();

            IWebElement popUp = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#bootsTrapper > ng-sidebar-container > div > div > main > contact > modal > div > div > div > div > div > div > h2")));
            string actualText = popUp.Text;
            string expectedText = "Your Inquiry has been successfully sent!";
            Assert.That(actualText, Is.EqualTo(expectedText), $"Text assertion failed! Expected: '{expectedText}', Actual: '{actualText}'");
            Console.WriteLine($"Contact Us Test:\n The test passed successfully! Expected: '{expectedText}', Actual: '{actualText}'");

            gotItBtn.Click();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
