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
    class UnitTestDatabase
    {

        [TestMethod]
        public void TestMethodAdd()
        {
            PiData data = new PiData(1,DateTime.Now,DateTime.Now,1,new Subjects(1,"Programmering",DateTime.Now));


        }

    }
}
