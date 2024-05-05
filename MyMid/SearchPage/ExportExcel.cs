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
    internal class ExportExcel : Login
    {
        [Test]
        public void ExportExcelTest()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-orange")));
            searchBtn.Click();
            Thread.Sleep(2000);
            IWebElement selectStone = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/search/div[4]/stone-table/div/div/section/div[2]/div/div/table/tbody[1]/tr/td[2]")));
            Thread.Sleep(2000);
            selectStone.Click();
            Thread.Sleep(1000);
            IWebElement exportExcelBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".search-actions > .pull-right:nth-child(2)")));
            exportExcelBtn.Click();
            Thread.Sleep(2000);

            string downloadDirectory = @"C:\Users\itay\Downloads";
            string filename = "MID Inventory.xlsx";
            string filePath = Path.Combine(downloadDirectory, filename);

            wait.Until(d => File.Exists(filePath));

            Assert.IsTrue(File.Exists(filePath) && Path.GetFileName(filePath) == "MID Inventory.xlsx", "File download verification failed.");
            Console.WriteLine("Export Excel Text:\n The test passed successfully");
            File.Delete(filePath);
            Console.WriteLine("File deleted");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
