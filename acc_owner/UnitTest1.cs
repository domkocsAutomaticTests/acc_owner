using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AccOwner
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new InternetExplorerDriver();
            baseURL = "http://clic-ftest-app1:81/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheAccOwnerTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.Navigate().GoToUrl(baseURL + "/AccownerList/List?fromMenu=True");
            driver.FindElement(By.Id("actionButton_New")).Click();
            driver.FindElement(By.Id("Input_Id")).Clear();
            driver.FindElement(By.Id("Input_Id")).SendKeys("00345678");
            driver.FindElement(By.Id("Input_SourceId")).Clear();
            driver.FindElement(By.Id("Input_SourceId")).SendKeys("5689");
            driver.FindElement(By.Id("Input_Name")).Clear();
            driver.FindElement(By.Id("Input_Name")).SendKeys("automatictest");
            driver.FindElement(By.Id("Input_Addr")).Clear();
            driver.FindElement(By.Id("Input_Addr")).SendKeys("automatictest");
            new SelectElement(driver.FindElement(By.Id("Input_CountryId"))).SelectByText("AFGHANISTAN");
            driver.FindElement(By.Id("Input_Phone1")).Clear();
            driver.FindElement(By.Id("Input_Phone1")).SendKeys("123456789");
            driver.FindElement(By.Id("Input_TaxInfo")).Clear();
            driver.FindElement(By.Id("Input_TaxInfo")).SendKeys("9965000936");
            driver.FindElement(By.Id("actionButton_Save")).Click();
            driver.FindElement(By.Id("actionButton_Validate")).Click();
            driver.FindElement(By.Id("actionButton_Validate")).Click();
            driver.FindElement(By.Id("actionButton_Back")).Click();
            driver.FindElement(By.Id("gvAccOwner_DXFREditorcol2_I")).Clear();
            driver.FindElement(By.Id("gvAccOwner_DXFREditorcol2_I")).SendKeys("automatictest");
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//tr[4]/td[3]")).Click(); Thread.Sleep(2000);
            driver.FindElement(By.Id("actionButton_Delete")).Click(); Thread.Sleep(2000);
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("actionButton_Validate")).Click(); Thread.Sleep(1000);
            driver.FindElement(By.Id("actionButton_Validate")).Click();
            driver.FindElement(By.Id("sessionCountdown")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
