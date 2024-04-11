using Microsoft.AspNetCore.Mvc;
using WebLivrariaAT.Models;
using WebLivrariaAT.Repositorios.Interfaces;

namespace WebLivrariaAT.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login(LoginSenhaViewModel loginSenha)
        {
            List<UsuarioViewModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            foreach (var usuario in usuarios)
            {
                if (usuario.email == loginSenha.email)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioViewModel usuario)
        {
            await _usuarioRepositorio.CriarUsuario(usuario);
            return RedirectToAction("Index", "Home", usuario);
        }
    }
}
