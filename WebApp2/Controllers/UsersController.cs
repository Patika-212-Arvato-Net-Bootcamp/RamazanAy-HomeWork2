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
    public class UsersController : ControllerBase
    {   
        private List<User> _users = FakeDb.GetUsers(10);//We want it to create 10 fake users
        [HttpGet("getUsers")]
        public List<User> Get()     //We want get all users from fake database as a list
        {
            return _users;
        }
        [HttpGet("getById")] //We want users to filter by ID.
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        [HttpPost("addUser")] 
        public User Post([FromBody] User user) // We want add new user to fake database
        {
            _users.Add(user);
            return user;
        }
        [HttpPut("editedUser")]
        public User Put([FromBody] User user) //Update existing user information
        {
            var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
            editUser.Name = user.Name;
            editUser.SurName = user.SurName;
            editUser.Adress = user.Adress;
            editUser.BootcamId = user.BootcamId;
            return user;
        }
        [HttpDelete("deleteUser")] // We want delete user to fake database
        public void Delete(int Id)
        {
            var deletedUser = _users.FirstOrDefault(x=>x.Id == Id);
            _users.Remove(deletedUser);
        }
    }
}
