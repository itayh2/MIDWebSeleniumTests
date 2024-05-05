using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.Quotes
{
    internal class ChangeStatuses : Login
    {
        [Test]
        public void ChangeStatusToNew()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement quotePage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-quotes")));
            quotePage.Click();

            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) label")));
            selectStone.Click();
            IWebElement changeStatusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".small:nth-child(2)")));
            changeStatusBtn.Click();
            IWebElement statusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".row:nth-child(1) .dropdown-btn")));
            statusBtn.Click();
            IWebElement chooseStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(1) > div")));
            chooseStatus.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            IWebElement status = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) .strong")));
            string actualText = status.Text;
            string expectedText = "New";
            Assert.That(actualText, Is.EqualTo(expectedText), "New Status Test - Failed");
            Console.WriteLine("New Status Test - Success");
        }
        [Test]
        public void ChangeStatusToPending()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement quotePage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-quotes")));
            quotePage.Click();
            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) label")));
            selectStone.Click();
            IWebElement changeStatusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".small:nth-child(2)")));
            changeStatusBtn.Click();
            IWebElement statusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".row:nth-child(1) .dropdown-btn")));
            statusBtn.Click();
            IWebElement chooseStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(2) > div")));
            chooseStatus.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            IWebElement status = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) .strong")));
            string actualText = status.Text;
            string expectedText = "Pending";
            Assert.That(actualText, Is.EqualTo(expectedText), "Pending Status Test - Failed");
            Console.WriteLine("Pending Status Test - Success");
        }
        [Test]
        public void ChangeStatusToSold()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement quotePage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-quotes")));
            quotePage.Click();
            IWebElement statusList = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-star-inserted:nth-child(1) > .col-xs-12:nth-child(1) .dropdown-btn:nth-child(1)")));
            statusList.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/quotes/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[3]")));
            addSoldStatus.Click();
            IWebElement addClosedStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/quotes/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[4]")));
            addClosedStatus.Click();
            Thread.Sleep(1000);
            statusList.Click();

            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) label")));
            selectStone.Click();
            IWebElement changeStatusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".small:nth-child(2)")));
            changeStatusBtn.Click();
            IWebElement statusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".row:nth-child(1) .dropdown-btn")));
            statusBtn.Click();
            IWebElement chooseStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(3) > div")));
            chooseStatus.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            IWebElement status = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) .strong")));
            string actualText = status.Text;
            string expectedText = "Sold";
            Assert.That(actualText, Is.EqualTo(expectedText), "Sold Status Test - Failed");
            Console.WriteLine("Sold Status Test - Success");
        }
        [Test]
        public void ChangeStatusToClosed()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement quotePage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".icon-quotes")));
            quotePage.Click();

            IWebElement statusList = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-star-inserted:nth-child(1) > .col-xs-12:nth-child(1) .dropdown-btn:nth-child(1)")));
            statusList.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/quotes/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[3]")));
            addSoldStatus.Click();
            IWebElement addClosedStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/quotes/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[4]")));
            addClosedStatus.Click();
            Thread.Sleep(1000);
            statusList.Click();

            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) label")));
            selectStone.Click();
            IWebElement changeStatusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".small:nth-child(2)")));
            changeStatusBtn.Click();
            IWebElement statusBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".row:nth-child(1) .dropdown-btn")));
            statusBtn.Click();
            IWebElement chooseStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(4) > div")));
            chooseStatus.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            IWebElement status = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".matching:nth-child(1) .strong")));
            string actualText = status.Text;
            string expectedText = "Closed";
            Assert.That(actualText, Is.EqualTo(expectedText), "Closed Status Test - Failed");
            Console.WriteLine("Closed Status Test - Success");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
