using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestClasses
    {
        // PiData Tests --------------------------------------------------------------------------- PiData Tests
        [TestMethod]
        public void PiDataConstructorTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new PiData(null, null, null));
        }

        // Subjects Tests ------------------------------------------------------------------------- Subjects Tests
        [TestMethod]
        public void SubjectsConstructorTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Subjects(null, null));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Subjects(-1, "Navn", DateTime.Now));
            Assert.ThrowsException<ArgumentException>(() => new Subjects("", DateTime.Now));
        }
    }
}
