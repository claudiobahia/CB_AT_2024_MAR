using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebLivrariaAT.Models;
using WebLivrariaAT.Repositorios.Interfaces;

namespace WebLivrariaAT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        public HomeController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<LivroViewModel> livros = await _livroRepositorio.BuscarTodosLivros();

            return View(livros);
        }

        public IActionResult Favoritos()
        {
            return View();
        }
        public IActionResult AdicionarLivro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
