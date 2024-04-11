using LivrariaAT.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string login, string senha)
        {
            if (login == "as@a.com" && senha == "123")
            {
                var token = TokenService.GenerateToken(new Models.Usuario());
                return Ok(token);
            }
            return BadRequest("login ou senha invalidos");
        }
    }
}
