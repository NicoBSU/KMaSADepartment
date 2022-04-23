using KMaSA.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials userCreds)
        {
            return Ok();
        }
    }
}
