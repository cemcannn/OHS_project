using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OHSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            var response = _service.Login(email, password);
            return Ok(response);
        }
    }
}
