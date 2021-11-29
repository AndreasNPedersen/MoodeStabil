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
        DateTime dateData = DateTime.Now;
        IPiDataManager mgr;
        
        public UnitTestDatabase() {
            mgr = new PiDataManager(new AndreasDatabaseContext());
        }

        [TestMethod]
        public void TestMethodAdd()
        {

           
            
            Subjects sub = new Subjects("Programmering", dateData);
            sub.Id = 1;
            

            // made the data, data from Pi
            PiData data = new PiData(dateData,dateData,sub);
            int countOriData = mgr.GetAllPiData().Count;
            
            mgr.AddPiData(dateData);

            int countdata = mgr.GetAllPiData().Count;
            Assert.AreEqual(data.Date, mgr.GetAllPiData().Find(c =>c.Date == data.Date).Date);
            Assert.AreEqual(countOriData + 1, countdata);

        }
        //test date på subject en weekend
        [TestMethod]
        public void TestMethodAddException()
        {
            DateTime date = new DateTime(2021,2,28);
            
            Assert.IsFalse(mgr.AddPiData(date));
        }

        [TestMethod]
        public void TestMethodGetAllPiData()
        {
            
            DateTime time = DateTime.Parse("29-11-2021 09:18:46");
            DateTime timeTwo = DateTime.Parse("22-11-2021 19:48:17"); 
            Subjects sub = new Subjects("Fag 2", timeTwo);
            sub.Id = 5;

            // made the data, data from Pi
            PiData data = new PiData(timeTwo, time, sub);
            data.Id = 10;
            Assert.AreEqual(data, mgr.GetAllPiData().Find(c => c.Id==data.Id));
        }
       

    }
    
}
