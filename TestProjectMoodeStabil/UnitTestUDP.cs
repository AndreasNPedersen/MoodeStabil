using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProjectMoodeStabil
{
    [TestClass]
    public class UnitTestUDP
    {
        [TestMethod]
        public void TestReciveData()
        {

            UdpClient client = new UdpClient(7);
            byte[] data;
            bool modtagetData = true;

            while (modtagetData)
            {
                IPEndPoint remoteEP = null;

                // modtager
                data = client.Receive(ref remoteEP);

                string str = Encoding.UTF8.GetString(data);
                DateTime date = Convert.ToDateTime(str);
                if (str.Length > 0)
                {
                    Assert.IsTrue(true);
                    Assert.AreEqual(DateTime.Now.Hour, date.Hour);
                }
            }
        }

        [TestMethod]
        public void TestDataLogic()
        {


        }


    }
}
