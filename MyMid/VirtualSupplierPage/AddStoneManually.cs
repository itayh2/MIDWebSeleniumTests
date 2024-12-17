using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.VirtualSupplierPage
{
    internal class AddStoneManually : Login
    {
        const string certificateStr = "2171452939";
        [Test]
        public void AddStoneManuallyTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement vsBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-virtual-supplier")));
            vsBtn.Click();
            IWebElement prefixIH = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-star-inserted:nth-child(17) > td:nth-child(4)")));
            prefixIH.Click();
            IWebElement addStoneBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-1 > .btn-orange")));
            addStoneBtn.Click();
            IWebElement certIdTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("td:nth-child(4) .ng-untouched")));
            certIdTextBox.SendKeys(certificateStr);
            Thread.Sleep(1000);

            IWebElement verifyIconBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-reset-md")));
            verifyIconBtn.Click();
            Thread.Sleep(1000);

            IWebElement continue1Btn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn:nth-child(5)")));
            continue1Btn.Click();
            //IWebElement resetVmid = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-reset-small")));
            //resetVmid.Click();
            Thread.Sleep(1000);
            IWebElement continue2Btn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            continue2Btn.Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("body > app-root > mat-sidenav-container > mat-sidenav-content > div > div > main > member-details > div.container > virtual-supplier-upload > div > div > section > div:nth-child(1) > div > button")).Click();
            Thread.Sleep(1000);
            IWebElement searchCertIdTextBox = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".normal")));
            searchCertIdTextBox.SendKeys(certificateStr);
            IWebElement certIdText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#col-5 span:nth-child(1)")));
            Thread.Sleep(1000);
            int numberOfResults = int.Parse(driver.FindElement(By.CssSelector(".layer")).Text.Split(" ")[0]);
            int expectedNumber = 1;
            Assert.That(numberOfResults, Is.EqualTo(expectedNumber), "The stone was not added successfully");
            Console.WriteLine("The stone has been successfully added");
        }
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
