using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp2.Entities;
using WebApp2.FakeData;

namespace WebApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootCampController : ControllerBase
    {
        private List<BootCamp> _bootCamps = FakeDb.GetBootCamps(10);
        [HttpGet("getBootCamps")]
        public List<BootCamp> Get()     //We want get all users from fake database as a list
        {
            return _bootCamps;
        }
        [HttpGet("getBootcampById")] //We want users to filter by ID.
        public BootCamp GetBootCampbyId(int id)
        {
            var bootcamp = _bootCamps.FirstOrDefault(x => x.Id == id);
            return bootcamp ;
        }
        [HttpPost("AddBootcamp")] // We want add new user to fake database
        public BootCamp AddBootcamp(BootCamp bootCamp)
        {
            _bootCamps.Add(bootCamp);
            return bootCamp;
        }
        [HttpDelete("deleteBootcamp")] // We want delete user to fake database
        public void DeletBootcamp(int id)
        {
            var deletedBootcamp = _bootCamps.FirstOrDefault(x => x.Id == id);
             _bootCamps.Remove(deletedBootcamp);
        }
        [HttpPut("editedBootcamp")] //Update existing user information
        public BootCamp UpdateBootcamp(BootCamp bootCamp)
        {
            var editBootcamp = _bootCamps.FirstOrDefault(x => x.Id == bootCamp.Id);
            editBootcamp.BootCampName = bootCamp.BootCampName;
            return bootCamp;
        }

    }
}
