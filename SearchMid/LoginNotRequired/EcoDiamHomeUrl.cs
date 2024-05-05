using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIDWebTests.SearchMid.LoginNotRequired
{
    internal class EcoDiamHomeUrl : SearchEcoDiamLogin
    {
        [Test]
        public void NavigateToEcoDiamHomeUrlTest()
        {
            WaitForVisibleAndPerformAction(By.CssSelector(".icon-home"), (homeBtn) =>
            {
                homeBtn.Click();
            });
            string expectedUrl = "https://ecodiam.diamonds/";
            string? newWindowHandle = WaitForNewWindowHandle(10);
            driver.SwitchTo().Window(newWindowHandle);

            Assert.That(driver.Url, Is.EqualTo(expectedUrl), $"Text assertion failed! Expected: '{expectedUrl}', Actual: '{driver.Url}'");
            Console.Write($"Navigate To EcoDiam Home Url Test passed successfully:\nExpected: '{expectedUrl}', Actual: '{driver.Url}'");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
