using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MoodeStabil.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoodeStabil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiDataController : ControllerBase
    {
        PiDataManager mgr;

        public PiDataController(AndreasDatabaseContext _database)
        {
            mgr = new PiDataManager(_database);
        }
        // GET: api/<PiDataController>
        [HttpGet]
        public IEnumerable<PiData> Get()
        {
            return mgr.GetAllPiData();
        }

        // GET api/<PiDataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PiDataController>
        // DateTime value should look exactly like this : "2021-11-25T21:18:19.2693889+01:00" (Json format of DateTime.Now)
        [HttpPost]
        public void Post([FromBody] DateTime value)
        {
            mgr.AddPiData(value);
        }

        // PUT api/<PiDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PiDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
