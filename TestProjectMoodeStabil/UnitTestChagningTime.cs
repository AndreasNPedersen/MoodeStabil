using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodeStabil.Manager;
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
        static string DriverDirectory = "C:\\Driver";
        static string URL = "";
        private  List<Subjects> subjects;
        IManageSubjects mgr;

        //public UnitTestChagningTime(AndreasDatabaseContext _data)
        //{
        //    mgr = new ManageSubjects(_data);
        //}
        [TestInitialize]
        public void StartUp()
        {
            // Data should be changed when real data is implemented
            subjects = new List<Subjects>() {
            new Subjects(1,"System Udvikling",new DateTime(2021,02,03)),
            new Subjects(2,"System Udvikling", new DateTime(2021,11,26)),
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
