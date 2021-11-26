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
        
        public UnitTestDatabase(AndreasDatabaseContext _data) {
            mgr =new PiDataManager(_data);
        }

        [TestMethod]
        public void TestMethodAdd()
        {

            DateTime dateData = DateTime.Now;
            
            Subjects sub = new Subjects("Programmering", dateData);
            sub.Id = 1;
            //List<Subjects> subjects = mgr.GetSubjects();

            // made the data, data from Pi
            PiData data = new PiData(dateData,dateData,sub);
            int countOriData = mgr.GetAllPiData().Count;
            
            mgr.AddPiData(dateData);
            int countdata = mgr.GetAllPiData().Count;
            Assert.AreEqual(data, mgr.GetAllPiData().Find(c =>c.Id ==data.Id));
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
            Subjects sub = new Subjects("Programmering", dateData);
            sub.Id = 1;
            //List<Subjects> subjects = mgr.GetSubjects();

            // made the data, data from Pi
            PiData data = new PiData(dateData, dateData, sub);
            Assert.AreEqual(data, mgr.GetAllPiData().Find(c => c.Date==dateData));
        }
        [TestMethod]
        public void TestMethodGetAllSubjectsData()
        {
            DateTime dateData = DateTime.Now;
            Subjects sub = new Subjects("Programmering", dateData);
            sub.Id = 1;
            //List<Subjects> subjects = mgr.GetSubjects();
            //Assert.AreEqual(sub, subjects[0]);
        }

    }
    
}
