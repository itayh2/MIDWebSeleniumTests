using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginNotRequired
{
    internal class Registration : SearchMidLogin
    {
        private IWebElement registerBtn => driver.FindElement(By.CssSelector(".light"));
        private IWebElement emailInput => driver.FindElement(By.Id("1-email"));
        private IWebElement passwordInput => driver.FindElement(By.Id("1-password"));
        private IWebElement fisrtNameInput => driver.FindElement(By.Id("1-first_name"));
        private IWebElement lastNameInput => driver.FindElement(By.Id("1-last_name"));
        private IWebElement submitBtn => driver.FindElement(By.Id("1-submit"));
        private IWebElement companyTextBox => driver.FindElement(By.CssSelector("#Company"));
        private IWebElement registerBtn2 => driver.FindElement(By.XPath("/html/body/app-root/app-registration/body/div/form/div[10]/button"));


        [Test]
        public void SignUpTest()
        {
            string initialWindowHandle = driver.CurrentWindowHandle;
            registerBtn.Click();
            string? newWindowHandle = WaitForNewWindowHandle(20);
            driver.SwitchTo().Window(newWindowHandle);
            WaitForVisibleAndPerformAction(By.LinkText("Sign Up"), (signUpBtn) =>
            {
                signUpBtn.Click();
            });
            emailInput.SendKeys("roy2@gmail.com");
            passwordInput.SendKeys("royChen2");
            fisrtNameInput.SendKeys("Roy");
            lastNameInput.SendKeys("Chen");
            submitBtn.Click();
            Thread.Sleep(5000);
            WaitForVisibleAndPerformAction(By.CssSelector("#Company"), (companyTextBox) =>
            {
                companyTextBox.SendKeys("intel");
            });
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("/html/body/app-root/app-registration/body/div/form/div[5]/countries-autocomplete/input")).SendKeys("Israel");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("inlineRadio3")).Click();
            Thread.Sleep(1000);
            registerBtn2.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Window(initialWindowHandle);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-tns-c20-0 > .icon-user"))).Click();
            Thread.Sleep(1000);
            string actualText = "";
            IWebElement iconUser = driver.FindElement(By.CssSelector(".bold-text"));
            actualText = iconUser.Text;
            string expectedText = "Hi Roy Chen!";
            Assert.That(expectedText, Is.EqualTo(actualText), "No Success");
            Console.WriteLine("Success");
        }
    }
}
