using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;


namespace SeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        public List<string> inputSequence;
        public List<string> resultSequence = new List<string> { };
        const string lineBreak = "\r\n";

        int sequenceIndex;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            baseURL = "https://etjanster.lantmateriet.se/";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
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

        public void SetInputSequenceIndex(int newIndex)
        {
            sequenceIndex = newIndex;
        }

        public void UploadTestData(List<string> inputData)
        {
            inputSequence = inputData;
            SetInputSequenceIndex(0);
        }

        public List<string> GetTestResult()
        {
            return resultSequence;
        }


        [TestMethod]
        public void TestMethodLogin()
        {
            driver.Navigate().GoToUrl(baseURL + "/lina");
            waitForElementPresent(By.Name("Ecom_Password"));
            driver.FindElement(By.Name("Ecom_Password")).Clear();
            driver.FindElement(By.Name("Ecom_Password")).SendKeys("QwE12AsD");
            driver.FindElement(By.Name("Ecom_User_ID")).Clear();
            driver.FindElement(By.Name("Ecom_User_ID")).SendKeys("grasosbi");
            driver.FindElement(By.Id("loginButton2")).Click();
            waitForElementPresent(By.Id("searchRealPropertyForm:inputRealProperty"));
            Assert.AreEqual("Sök via beteckning", driver.FindElement(By.LinkText("Sök via beteckning")).Text);
        }

        public void TestMethodLogout()
        {
            driver.FindElement(By.LinkText("Logga ut")).Click();
        }

        [TestMethod]
        public void TestMethodVerifyByIndex()
        {
            try
            {
                waitForElementPresent(By.Id("searchRealPropertyForm:inputRealProperty"));
            }
            catch (Exception)
            {
                TestMethodToIncementSession();
                waitForElementPresent(By.Id("searchRealPropertyForm:inputRealProperty"));
            }
            driver.FindElement(By.Id("searchRealPropertyForm:inputRealProperty")).Clear();
            driver.FindElement(By.Id("searchRealPropertyForm:inputRealProperty")).SendKeys(inputSequence[sequenceIndex].ToUpper());
            driver.FindElement(By.Id("searchRealPropertyForm:searchRealPropertyButton")).Click();
            try
            {
                string breadcrumText = driver.FindElement(By.Id("breadCrumb")).Text;

                if (Regex.IsMatch(driver.FindElement(By.Id("breadCrumb")).Text, "^" + inputSequence[sequenceIndex].ToUpper() + "[\\s\\S]*$"))
                {
                    resultSequence.Add(inputSequence[sequenceIndex] + ";" + inputSequence[sequenceIndex]);
                }
                else if (driver.FindElement(By.Id("breadCrumb")).Text == " ")
                {
                    resultSequence.Add(inputSequence[sequenceIndex] + ";ERROR");
                    driver.Navigate().GoToUrl(baseURL + "/lina");
                }
                else
                {
                    resultSequence.Add(inputSequence[sequenceIndex] + ";NOK");
                }
            }
            catch (Exception)
            {

                resultSequence.Add(inputSequence[sequenceIndex] + ";ERROR");
            }

        }

        [TestMethod]
        public void TestMethodToIncementSession()
        {
            driver.FindElement(By.LinkText("Adressområde")).Click();
            driver.FindElement(By.Id("main_menu_ajourhallning_link")).Click();
            driver.FindElement(By.LinkText("Sök via beteckning")).Click();
        }

        private void waitForElementPresent(By by)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(by)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
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
