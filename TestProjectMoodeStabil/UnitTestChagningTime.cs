using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodeStabil.Manager;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestChagningTime
    {
        //private IManageSubjects mgr = new ManageSubjects(new AndreasDatabaseContext());
        static string DriverDirectory = "C:\\DRIVERS";
        static string URL = "file:///C:/Users/tobia/OneDrive/Skrivebord/MoodeStabil/MoodestabilWebApp/subjects.html";
        static IWebDriver driver = new ChromeDriver(DriverDirectory);
        static IWebElement getAllButtonElement;
        static IWebElement AddButtonElement;
        static IWebElement DeleteButtonElement;
        static IWebElement resultElement1;
        static IWebElement inputFeildAddName;
        static IWebElement inputFeildAddMeetingTime;
        static IWebElement inputFeildDeleteWithId;
        static IWebElement inputFeildUpdateId;
        static IWebElement inputFeildUpdateName;
        static IWebElement inputFeildUpdateDate;
        static IWebElement updateButtonElement;
        static WebDriverWait waiting;
        

        private List<Subjects> subjects;
        IManageSubjects mgr;

        //public UnitTestChagningTime(AndreasDatabaseContext _data)
        //{
        //    mgr = new ManageSubjects(_data);
        //}
        [ClassInitialize]
        public static void TestClassSetUp(TestContext context)
        {
            /*waiting = new WebDriverWait(driver, TimeSpan.FromSeconds(5))*/;
            driver.Navigate().GoToUrl(URL);
            getAllButtonElement = driver.FindElement(By.Id("enterbut"));
            AddButtonElement = driver.FindElement(By.Id("addButton"));
            DeleteButtonElement = driver.FindElement(By.Id("deleteButton"));
            resultElement1 = driver.FindElement(By.Id("result1"));
            inputFeildAddName = driver.FindElement(By.Id("nameForAdd"));
            inputFeildAddMeetingTime = driver.FindElement(By.Id("subjectMeetTime"));
            inputFeildDeleteWithId = driver.FindElement(By.Id("idInputDelete"));
            inputFeildUpdateId = driver.FindElement(By.Id("idToBeUpdated"));
            inputFeildUpdateName = driver.FindElement(By.Id("subjectNameToBeUpdated"));
            inputFeildUpdateDate = driver.FindElement(By.Id("dateTimeToBeUpdated"));
            updateButtonElement = driver.FindElement(By.Id("updateButton"));

            //resultElement2 = driver.FindElement(By.Id("result2"));

        }
        public void ClearFeilds()
        {
            inputFeildAddName.Clear();
            inputFeildAddMeetingTime.Clear();
            inputFeildDeleteWithId.Clear();
            inputFeildUpdateId.Clear();
            inputFeildUpdateName.Clear();
            inputFeildUpdateDate.Clear();
        }
        [TestMethod]
        public void GetAllTest()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // decorator pattern?
            IWebElement subjects = wait.Until(d => d.FindElement(By.Id("result1")));
            Console.WriteLine(subjects.Text.Trim());
            Assert.IsNotNull(subjects.Text.Trim());
        }
        [TestMethod]
        public void DeleteAndAddFlowSelinumTest()
        {
            inputFeildAddName.SendKeys("This Is gonna be deleted");
            DateTime dateTime = new DateTime(2002, 09, 20, 20, 20, 20);
            inputFeildAddMeetingTime.SendKeys(dateTime.ToString());
            AddButtonElement.Click();
            getAllButtonElement.Click();

            Thread.Sleep(1000);
            Assert.IsTrue(resultElement1.Text.Contains("This Is gonna be deleted"));
            int id = mgr.GetAll().Last().Id;
            inputFeildDeleteWithId.SendKeys($"{id}");
            Thread.Sleep(1000);
            DeleteButtonElement.Click();
            Thread.Sleep(1000);
            getAllButtonElement.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(resultElement1.Text.Contains("This Is gonna be deleted"));

            ClearFeilds();

        }
        [TestMethod]
        public void UpdateDeleteAndAddFlowSelinumTest()
        {

            inputFeildAddName.SendKeys("This Is gonna be updated");
            DateTime dateTime = new DateTime(2002, 09, 20, 20, 20, 20);
            inputFeildAddMeetingTime.SendKeys(dateTime.ToString());
            AddButtonElement.Click();
            Thread.Sleep(2000);
            getAllButtonElement.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(resultElement1.Text.Contains("This Is gonna be updated"));

            Thread.Sleep(2000);
            int id = mgr.GetAll().Last().Id;
            inputFeildUpdateId.SendKeys($"{id}");
            Thread.Sleep(1000);
            inputFeildUpdateName.SendKeys("This has Been Updated");
            inputFeildUpdateDate.SendKeys(dateTime.ToString());
            Thread.Sleep(1000);
            updateButtonElement.Click();
            Thread.Sleep(1000);
            getAllButtonElement.Click();
            Thread.Sleep(1000);
            Assert.IsTrue(resultElement1.Text.Contains("This has Been Updated"));


            inputFeildDeleteWithId.SendKeys($"{id}");
            Thread.Sleep(1000);
            DeleteButtonElement.Click();
            Thread.Sleep(1000);
            getAllButtonElement.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(resultElement1.Text.Contains("This has Been Updated"));

            ClearFeilds();



        }
        [TestInitialize]
        public void StartUp()
        {
            // Data should be changed when real data is implemented
            subjects = new List<Subjects>() {
            new Subjects(1,"System Udvikling",new DateTime(2021,02,03)),
            new Subjects(2,"System Udvikling", new DateTime(2021,12,10)),
            new Subjects(3,"Teknik", new DateTime(2021,11,24)),
            new Subjects(4,"Fag 1", new DateTime(2021,11,23)),
             new Subjects(5,"Fag 2", new DateTime(2021,11,22)),



        };
            
            mgr = new ManageSubjects(new AndreasDatabaseContext());
            mgr.Update(subjects[0]);


        }
        [TestCleanup]
        public void CleanUp()
        {
            
        }
        [TestMethod]
        public void TestGetById()
        {
            Subjects subjectsById = mgr.GetById(1);
            //Console.WriteLine(subjectsById.ToString(), subjects[1].ToString());
            Assert.AreEqual(subjects[0], subjectsById);
        }
       
        [TestMethod]
        public void TestGetAll()
        {
            List<Subjects> AllSubjects = mgr.GetAll().ToList();
            List<Subjects> First3Subjects = new();
          
            //Assert.AreEqual(AllSubjects[1], subjects[1]);
            CollectionAssert.AreEqual(subjects, AllSubjects);


        }

        [TestMethod]
        public void TestChagningTimeOfSubject()
        {
            Subjects aSubject = new(1, "Systemudvikling", DateTime.Now);
            mgr.Update(aSubject);
            Subjects changedSubject = mgr.GetById(1);


            Assert.AreEqual(aSubject, changedSubject);

        }
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void TestChangingTimeOfSubject()
        {
            Subjects aSubject = new(40000, "Systemudvikling", DateTime.Now);
            mgr.Update(aSubject);
        }

        [TestMethod]
        public void TestAddSubject()
        {
            Subjects aSubject = new( "LinjeFag", DateTime.Now);
            mgr.AddSubject(aSubject);
            // Assert.AreEqual(subjects.Count + 1, mgr.GetAll().ToList().Count);
            Thread.Sleep(200);
            Subjects subjectFromMgr = mgr.GetAll().Last();
            Assert.AreEqual(aSubject, subjectFromMgr);
            mgr.DeleteItem(subjectFromMgr.Id);
        }


    }
}
