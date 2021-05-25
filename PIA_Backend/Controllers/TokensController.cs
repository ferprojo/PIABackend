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
    //AQUI NO VA AUTHORIZE PORQUE NO NECESITAS UN TOKEN PARA OBTENER OTRO TOKEN
    public class TokensController : ControllerBase
    {

        [HttpPost]
        public IActionResult GetToken([FromBody] UserModel user)
        {
            return Ok(new TokenService().GetToken(user));
        }
    }
}
