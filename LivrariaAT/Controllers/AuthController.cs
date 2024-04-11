using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Services;
using Microsoft.AspNetCore.Mvc;
using LivrariaAT.Models;

namespace LivrariaAT.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUsurarioRepositorio _usurarioRepositorio;

        public AuthController(IUsurarioRepositorio usurarioRepositorio)
        {
            _usurarioRepositorio = usurarioRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string login, string senha)
        {
            List<Usuario> usuarios = await _usurarioRepositorio.BuscarTodosUsuarios();
            foreach (var usuario in usuarios)
            {
                if (login == usuario.email && senha == usuario.password)
                {
                    var token = TokenService.GenerateToken(new Models.Usuario());
                    return Ok(token);
                }
            }
            return BadRequest("login ou senha invalidos");
        }
    }
}
