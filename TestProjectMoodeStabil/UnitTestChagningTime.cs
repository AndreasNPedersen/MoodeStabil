using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodeStabil.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestChagningTime
    {
        private IManageSubjects mgr = new ManageSubjects();
        private  List<Subjects> subjects;
        [TestInitialize]
        public void StartUp()
        {
            // Data should be changed we real data is implemented
            subjects = new List<Subjects>() {
            new Subjects(1,"Programming",DateTime.Now),
            new Subjects(2,"Systemudvikling", new DateTime(2021,2,3,9,10,10)),
            new Subjects(3,"Technology", new DateTime(2021,2,4,9,10,10)),
            
           
        };
            mgr.ReplaceList();
      

           
        }
        [TestMethod]
        public void TestGetById()
        {
            Subjects subjectsById = mgr.GetById(1);
            Console.WriteLine(subjectsById.ToString(), subjects[0].ToString());
            Assert.AreEqual(subjects[0], subjectsById);
        }
       
        [TestMethod]
        public void TestGetAll()
        {
            List<Subjects> AllSubjects = mgr.GetAll().ToList();
            CollectionAssert.AreEqual(subjects, AllSubjects);
          

        }

        [TestMethod]
        public void TestChagningTimeOfSubject()
        {
            Subjects aSubject = new(2, "Systemudvikling", DateTime.Now);
            mgr.Update(aSubject);
            Subjects changedSubject = mgr.GetById(2);
           
            
            Assert.AreEqual(aSubject, changedSubject);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChangingTimeOfSubject()
        {
            Subjects aSubject = new(40000, "Systemudvikling", DateTime.Now);
            mgr.Update(aSubject);
        }

        [TestMethod]
        public void TestAddSubject()
        {
            Subjects aSubject = new(10, "LinjeFag", DateTime.Now);
            mgr.AddSubject(aSubject);
            Assert.AreEqual(subjects.Count + 1, mgr.GetAll().ToList().Count);
            Subjects subjectFromMgr = mgr.GetById(10);
            Assert.AreEqual(aSubject, subjectFromMgr);
        }
      

    }
}
