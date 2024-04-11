using WebLivrariaAT.Models;
using Microsoft.AspNetCore.Mvc;
using WebLivrariaAT.Repositorios.Interfaces;

namespace WebLivrariaAT.Controllers
{
    public class CapituloController : Controller
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly ICapituloRepositorio _capituloRepositorio;

        public CapituloController(ILivroRepositorio livroRepositorio, ICapituloRepositorio capituloRepositorio)
        {
            _livroRepositorio = livroRepositorio;
            _capituloRepositorio = capituloRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarCapitulo(int livroId)
        {
            return View(new CapituloViewModel { livroid = livroId });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCapitulo(CapituloViewModel capitulo)
        {
            await _capituloRepositorio.CriarCapitulo(capitulo);
            await AtualizarUttAtt(capitulo.livroid);

            return RedirectToAction("Index", "Home");
        }

        [HttpPut]
        public async Task<LivroViewModel> AtualizarUttAtt(int livroid)
        {
            LivroViewModel livro = await _livroRepositorio.BuscarLivroPorId(livroid);
            await _livroRepositorio.AtualizarLivro(livro,livroid);

            return livro;
        }

        [HttpGet]
        public async Task<IActionResult> LerCapitulo(int livroId)
        {
            var livro = await _livroRepositorio.BuscarLivroPorId(livroId);
            var capitulos = await _capituloRepositorio.BuscarTodosCapitulosDeLivro(livroId);


            var capLivroViewModel = new CapLivroViewModel
            {
                livro = livro,
                capitulos = capitulos
            };

            return View(capLivroViewModel); 
        }
    }
}
