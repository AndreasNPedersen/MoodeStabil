using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestWebApp
    {
        static MyLocalDirectories directories = new MyLocalDirectories();
        static string DriverDirectory = "";

        static string URL = "https://moedestabil.azurewebsites.net/";

        static IWebDriver driver = null;

        // WEB ELEMENTS
        // Simple Elements
        static IWebElement updateButton;
        static IWebElement downloadButton;

        // Dropdowns
        static IWebElement datePicker;
        static SelectElement dateRange = new SelectElement(datePicker);

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // Set Driver
            DriverDirectory = directories.GetWebDriver();
            //driver = new ChromeDriver(DriverDirectory);
            driver = new FirefoxDriver(DriverDirectory);

            // Go to website
            driver.Navigate().GoToUrl(URL);

            // Find Elements to test
            updateButton      = driver.FindElement(By.Id("updateButton"));
            downloadButton    = driver.FindElement(By.Id("downloadButton"));
            datePicker        = driver.FindElement(By.Id("datePicker"));

            dateRange.SelectByValue("Last 30 Days");
        }

        [TestInitialize]
        public void TestInit()
        {
            
        }

        [TestMethod]
        public void TestDownload()
        {
            Thread.Sleep(500);
            try
            {
                updateButton.Click();
            }
            catch
            {
                Assert.Fail();
            }
            Thread.Sleep(500);
        }

        [ClassCleanup]
        public static void TestTearDown()
        {
            driver.Quit();
        }
    }
}
