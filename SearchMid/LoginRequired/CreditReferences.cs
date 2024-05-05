using OpenQA.Selenium.Interactions;
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
    internal class CreditReferences : SearchMidLogin
    {
        private IWebElement contactFirstName => driver.FindElement(By.Id("last_name"));
        private IWebElement contactLastName => driver.FindElement(By.Id("First_Name"));
        private IWebElement contactEmail => driver.FindElement(By.Id("email"));
        private IWebElement contactPhone => driver.FindElement(By.Id("phone"));
        private IWebElement saveReference => driver.FindElement(By.XPath("//*[@id=\"bootsTrapper\"]/ng-sidebar-container/div/div/main/credit-references/div[1]/div/div[2]/div/button"));


        [Test]
        public void AddCreditReference()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement creditReferencesBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(4) .account-settings-text")));
            creditReferencesBtn.Click();
            Thread.Sleep(500);

            WaitForVisibleAndPerformAction(By.CssSelector(".col-lg-12:nth-child(1) .icon-delete"), (deleteBtn) =>
            {
                deleteBtn.Click();
            });
            Thread.Sleep(1000);

            WaitForVisibleAndPerformAction(By.CssSelector(".col-lg-12:nth-child(1) .icon-delete"), (deleteBtn) =>
            {
                deleteBtn.Click();
            });
            Thread.Sleep(500);

            WaitForVisibleAndPerformAction(By.CssSelector(".icon-delete"), (deleteBtn) =>
            {
                deleteBtn.Click();
            });
            Thread.Sleep(1000);
            IWebElement addReferenceBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-grey")));
            addReferenceBtn.Click();

            WaitForVisibleAndPerformAction(By.CssSelector(".btn-grey"), (addReferenceBtn) =>
            {
                addReferenceBtn.Click();
            });
            Thread.Sleep(500);
            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-edit-large")));
            editBtn.Click();

            Thread.Sleep(500);
            IWebElement companyTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("billing_suite_number")));
            companyTextBox.SendKeys("intel");

            Thread.Sleep(500);
            companyTextBox.Click();
            Thread.Sleep(1000);
            {
                var element = driver.FindElement(By.CssSelector(".col-lg-9 #billing_suite_number"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            contactFirstName.SendKeys("Roy");
            contactLastName.SendKeys("Chen");
            contactEmail.SendKeys("roy1@gmail.com");
            Thread.Sleep(3000);

            driver.FindElement(By.Id("phone")).Clear();
            if (contactPhone.Text == "")
            {
                contactPhone.SendKeys("+972523214567");
            }
            saveReference.Click();
            string[] actualText =
                {
                driver.FindElement(By.CssSelector(".address-row:nth-child(2)")).Text,
                driver.FindElement(By.CssSelector(".address-row:nth-child(3)")).Text + " " + driver.FindElement(By.CssSelector(".address-row:nth-child(4)")).Text + " " + driver.FindElement(By.CssSelector(".address-row:nth-child(5)")).Text,
                driver.FindElement(By.CssSelector(".address-row:nth-child(6)")).Text,
                driver.FindElement(By.CssSelector(".address-row:nth-child(7)")).Text,
                driver.FindElement(By.CssSelector(".address-row:nth-child(8)")).Text,
                };
            string[] expectedText = { "Intel Ocotillo Campus", "4500 South Dobson Road Chandler Arizona 85248 United States", "roy1@gmail.com", "Roy Chen", "+972 52-321-4567" };
            bool areEqual = actualText.SequenceEqual(expectedText);
            if (areEqual)
            {

                Console.WriteLine($"Add Credit Reference Test:\nText assertion passed successfully! Expected: {expectedText}, Actual: {actualText}");
            }
            else
            {
                Assert.Fail($"Add Credit Reference Test:\nText assertion failed! Expected: {expectedText}, Actual: {actualText}");
            }
        }
        [Test]
        public void DeleteCreditReference()
        {
            LoginTest("itay080297@gmail.com", "itayH123!");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement creditReferencesBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".nav-item:nth-child(4) .account-settings-text")));
            creditReferencesBtn.Click();
            Thread.Sleep(500);
            WaitForVisibleAndPerformAction(By.CssSelector(".col-lg-12:nth-child(1) .icon-delete"), (deleteBtn) =>
            {
                deleteBtn.Click();
            });
            Thread.Sleep(1000);
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
