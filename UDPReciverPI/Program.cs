using System;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModelLib;
using UDPReciverPI.Controller;

namespace UDPReciverPI
{
    class Program
    {
        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // https://www.windowscentral.com/how-open-port-windows-firewall
        // Use the network MGV-xxx to capture from local IoT devices (fake or real)
        private const int Port = 7000;
        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx



        public static async void ResetCounter()
        {
            var dateTimeNow = DateTime.Now;
            // Create new DoorTracking object with the newly created properties
            //  DoorData doorTracking = await TaskController.AddDoorDataAsync(resetDoorTracking);
        }

        static void Main(string[] args)
        {
            var Date = DateTime.Now;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (UdpClient socket = new UdpClient(ipEndPoint))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    var Datenow = DateTime.Now;
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                    //   Parse(message);
                  ;
                    string temp2 = "2021-12-10T10:22:00";
                    if (message.Contains("Door"))
                    { 
                        TaskController.AddDoorDataAsync();

                    }
                 //   DoorData newDoorTracking = new DoorData();
                    // This object is the result of the HTTP POST method that is used in this very line
                  //  DoorData doorTracking = TaskController.AddDoorDataAsync(newDoorTracking).Result;
                  //while (message.Length > 0)
                  //{
                  //    PiData newDoorTracking = new PiData(DateTime.Now, Date, null);
                  //    PiData doorTracking = TaskController.AddDoorDataAsync(newDoorTracking).Result;
                  //}

                }
            }
        }

            

    // To parse data from the IoT devices (depends on the protocol)
        private static void Parse(string response)
        {
            string[] parts = response.Split(' ');
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }

            //string temperatureLine = parts[0];
            //string temperatureStr = temperatureLine.Substring(temperatureLine.IndexOf(": ") + 2);
   
            //Console.WriteLine(temperatureStr);
          

        }
        // POST api/<PiDataController>
        // DateTime value should look exactly like this : "2021-11-25T21:18:19.2693889+01:00" (Json format of DateTime.Now)

    }


}
