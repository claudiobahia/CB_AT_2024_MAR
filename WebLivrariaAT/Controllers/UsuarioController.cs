using Microsoft.AspNetCore.Mvc;

namespace WebLivrariaAT.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
