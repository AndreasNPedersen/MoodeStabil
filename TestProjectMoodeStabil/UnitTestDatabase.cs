using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using MoodeStabil.Manager;
using System;
using System.Collections.Generic;


namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestDatabase
    {
        IPiDataManager mgr;
        [TestInitialize]
        public void StartUp() {
            mgr = new PiDataManager(new AndreasDatabaseContext());
        }

        [TestMethod]
        public void TestMethodAdd()
        {

            DateTime dateData = DateTime.Now;
            
            Subjects sub = new Subjects(1, "Programmering", dateData);
            List<Subjects> subjects = mgr.GetSubjects();

            // made the data, data from Pi
            PiData data = new PiData(dateData,dateData,sub);
            int countOriData = mgr.GetAllPiData().length;
            mgr.AddPiData(dateData);
            int countdata = mgr.GetAllPiData().length;
            Assert.AreEqual(data, mgr.GetAllPiData().find(c => c.Date));
            Assert.AreEqual(countOriData + 1, countdata);

        }
        //test date på subject en weekend
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethodAddException()
        {
            DateTime dateData = DateTime.Parse("6/19/2015 10:35:50");
            mgr.AddPiData(dateData);
        }

        [TestMethod]
        public void TestMethodGetAllPiData()
        {
            DateTime dateData = DateTime.Now;
            Subjects sub = new Subjects(1, "Programmering", dateData);
            List<Subjects> subjects = mgr.GetSubjects();

            // made the data, data from Pi
            PiData data = new PiData(dateData, dateData, sub);
            Assert.AreEqual(data, mgr.GetAllPiData().find(c => c.Date));
        }
        [TestMethod]
        public void TestMethodGetAllSubjectsData()
        {
            Subjects sub = new Subjects(1, "Programmering", dateData);
            List<Subjects> subjects = mgr.GetSubjects();
            Assert.AreEqual(sub, subjects[0]);
        }

    }
    
}
