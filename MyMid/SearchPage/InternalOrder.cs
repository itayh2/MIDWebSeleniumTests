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
    internal class InternalOrder : Login
    {
        [Test]
        public void InternalOrderTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(2000);
            IWebElement internalOrderStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#col-3 > div > button.btn-circle.orange.ng-tns-c59-8")));

            string isActive = internalOrderStatus.GetAttribute("class");
            if (!isActive.Contains("active"))
            {
                IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[2]")));
                Thread.Sleep(2000);
                selectStone.Click();
                Thread.Sleep(1000);
                IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-actions > .btn:nth-child(4)")));
                internalOrderBtn.Click();
                IWebElement addMember = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("member-input")));
                addMember.SendKeys("itay080297@gmail.com");
                IWebElement selectMember = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".completer-list-item:nth-child(2)")));
                selectMember.Click();
                IWebElement changeCountryBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".col-sm-12 > .btn:nth-child(6)")));
                changeCountryBtn.Click();
                IWebElement okBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".orange-btn")));
                okBtn.Click();
                Thread.Sleep(2000);
                internalOrderStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[3]/div/button[4]")));
                isActive = internalOrderStatus.GetAttribute("class");
                Assert.IsTrue(isActive.Contains("active"), "Internal Order - The action was not done successfully");
                Console.WriteLine("Add Internal Order - The test passed successfully");
            }
            else
            {
                IWebElement internalOrderIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[4]/mat-list-item/span/span/i")));
                internalOrderIcon.Click();
                IWebElement openIOWindow = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-8 > .ng-star-inserted")));
                openIOWindow.Click();
                IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-new-edit")));
                editBtn.Click();
                IWebElement completeBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".complete-btn")));
                completeBtn.Click();
                IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-new-save")));
                saveBtn.Click();
                Thread.Sleep(2000);
                IWebElement searchIcon = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".mat-mdc-list-item-unscoped-content > .icon-search")));
                searchIcon.Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector(".btn-orange")).Click();
                internalOrderStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[3]/div/button[4]")));
                isActive = internalOrderStatus.GetAttribute("class");
                Assert.IsTrue(!isActive.Contains("active"), "Internal Order - The action was not done successfully");
                Console.WriteLine("Remove Internal Order - The test passed successfully");
            }
        }
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
