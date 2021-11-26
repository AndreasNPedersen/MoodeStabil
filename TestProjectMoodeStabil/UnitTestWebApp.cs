using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using OpenQA.Selenium;
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

        static IWebElement downloadButton;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            // Set Driver
            DriverDirectory = directories.GetWebDriver();
            //driver = new ChromeDriver(DriverDirectory);
            driver = new FirefoxDriver(DriverDirectory);

            // Find Elements to test
            driver.Navigate().GoToUrl(URL);

            downloadButton = driver.FindElement(By.Id("downloadButton"));
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
                downloadButton.Click();
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
