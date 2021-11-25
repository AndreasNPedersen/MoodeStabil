using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
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
            new Subjects(2,"HE-Ho",DateTime.Now),
            new Subjects(3,"Pe-Ho", new DateTime(1998,2,3,9,10,10)),
            new Subjects(4,"Vi-Ho", new DateTime(1998,2,4,9,10,10)),
            new Subjects(5,"And-Ho", new DateTime(1998,2,5,9,10,10))
           
        };
        mgr = new ManageSubjects();
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
            mgr.update(99999999, new DateTime(2,2,2,2,2,2));
        }

    }
}
