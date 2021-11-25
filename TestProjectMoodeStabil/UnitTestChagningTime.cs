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
    public class UnitTestChagningTime
    {
        private IManageSubjects mgr;
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
        mgr = new ManageSubjects();
        }
        [TestMethod]
        public void TestGetById()
        {
            Subjects subjectsById = mgr.GetById(2);

            Assert.AreEqual(subjects[1], subjectsById);
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
            DateTime date = new(2, 2, 2, 2, 2, 2, 2);
            mgr.Update(2, date);
            Subjects changedSubject = mgr.GetById(2);
           
            
            Assert.AreEqual(date, changedSubject.SubjectMeetTime.Value);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChangingTimeOfSubject()
        {
            mgr.Update(99999999, new DateTime(2,2,2,2,2,2));
        }

    }
}
