using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reshare_proto_0._2.Models;
using Reshare_proto_0._2.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reshare_proto_0._2.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly MainContext _context;

        public TestController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUser()
        {
            List<UserModel> users = new List<UserModel>();
            users = await _context.Users.ToListAsync();
            LocationModel location = users[0].Location;
            return users;
        }

        [HttpPost]
        public void AddUser(UserModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.Add(user);
        }
    }
}
