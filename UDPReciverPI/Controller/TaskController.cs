using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace UDPReciverPI.Controller
{
    public class TaskController
    {
        private const string DoorsTrackingUri = "https://moodestabil.azurewebsites.net/api/pidata";


        public TaskController()
        {
        }


        public static async Task AddDoorDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(DateTime.Now);
                Console.WriteLine("JSON: " + jsonString);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(DoorsTrackingUri, content);
                //if (response.StatusCode == HttpStatusCode.Conflict)
                //{
                //    throw new Exception("PiData already exists. Try another id");
                //}

                //response.EnsureSuccessStatusCode();
                //string str = await response.Content.ReadAsStringAsync();
                //PiData copyOfNewDoorData = JsonConvert.DeserializeObject<PiData>(str);
            }
        }

       
        
    }
}
