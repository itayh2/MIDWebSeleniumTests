using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.MyMid.InternalOrders
{
    internal class ChangeStatuses : Login
    {
        [Test]
        public void ChangeStatusToNew()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(1) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "New";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "New Status Test - Failed");
            Console.WriteLine("New Status Test - Success");
        }
        [Test]
        public void ChangeStatusToInProgress()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(2) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "InProcess";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "InProcess Status Test - Failed");
            Console.WriteLine("InProcess Status Test - Success");
        }
        [Test]
        public void ChangeStatusToTransVia()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(3) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "TransVia";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "TransVia Status Test - Failed");
            Console.WriteLine("TransVia Status Test - Success");
        }
        [Test]
        public void ChangeStatusToUnknown()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(4) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "Unknown";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "Unknown Status Test - Failed");
            Console.WriteLine("Unknown Status Test - Success");
        }
        [Test]
        public void ChangeStatusToReceived()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(5) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "Received";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "Received Status Test - Failed");
            Console.WriteLine("Received Status Test - Success");
        }
        [Test]
        public void ChangeStatusToCancelled()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(6) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "Cancelled";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "Cancelled Status Test - Failed");
            Console.WriteLine("Cancelled Status Test - Success");
        }
        [Test]
        public void ChangeStatusToManuallyClosedOrder()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(7) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "ManuallyClosedOrder";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "ManuallyClosedOrder Status Test - Failed");
            Console.WriteLine("ManuallyClosedOrder Status Test - Success");
        }
        [Test]
        public void ChangeStatusToSold()
        {
            LoginTest();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement internalOrderBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".icon-internal-orders")));
            internalOrderBtn.Click();
            IWebElement ioStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".dropdown-multiselect__caret:nth-child(2)")));
            ioStatus.Click();
            Thread.Sleep(1000);
            IWebElement addReceivedStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[5]")));
            addReceivedStatus.Click();
            IWebElement addCancelledStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[6]")));
            addCancelledStatus.Click();
            IWebElement addManuallyClosedOrderStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[7]")));
            addManuallyClosedOrderStatus.Click();
            IWebElement addSoldStatus = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/app-root/mat-sidenav-container/mat-sidenav-content/div/div/main/internal-orders-table/dynamic-filters/div/div/section/div[2]/div/div[1]/dynamic-filter/div/div/div/ng-multiselect-dropdown/div/div[2]/ul[2]/li[8]")));
            addSoldStatus.Click();

            Thread.Sleep(1000);
            ioStatus.Click();

            IWebElement editBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".matching:nth-child(1) > #col-6 .icon")));
            editBtn.Click();
            IWebElement listBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .dropdown-multiselect__caret")));
            listBtn.Click();
            IWebElement chooseStatusBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".ng-untouched:nth-child(1) .multiselect-item-checkbox:nth-child(8) > div")));
            chooseStatusBtn.Click();
            IWebElement saveBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".save-btn")));
            saveBtn.Click();
            Thread.Sleep(2000);
            string actualText = driver.FindElement(By.CssSelector(".matching:nth-child(1) > #col-7 .text-orange")).Text;
            string ExpectedText = "Sold";
            Assert.That(actualText, Is.EqualTo(ExpectedText), "Sold Status Test - Failed");
            Console.WriteLine("Sold Status Test - Success");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
