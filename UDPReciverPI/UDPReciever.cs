using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPReciverPI
{
    public class UDPReciever
    {
        public UDPReciever(){}

        public void Start()
        {
            UdpClient client = new UdpClient(7773);
            byte[] data;

            while (true)
            {
                IPEndPoint remoteEP = null;

                data = client.Receive(ref remoteEP);
                Console.WriteLine();
            }
        }

    }
}
