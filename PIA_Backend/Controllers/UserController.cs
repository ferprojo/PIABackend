using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIA_Backend.Backend;
using PIA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void addUser([FromBody] UserModel newUser)
        {
            new UserService().AddNewUser(newUser);
        }
    }
}
