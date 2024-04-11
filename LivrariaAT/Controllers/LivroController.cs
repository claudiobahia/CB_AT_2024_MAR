using LivrariaAT.Models;
using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Repositorios;
using LivrariaAT.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

       [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Livro>>> BuscarTodosLivros()
        {
            List<Livro> _livros = await _livroRepositorio.BuscarTodosLivros();
            return Ok(_livros);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> BuscarLivroPorId(int id)
        {
            Livro _livro = await _livroRepositorio.BuscarLivroPorId(id);
            return Ok(_livro);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Livro>> CriarLivro([FromBody] Livro livro)
        {
            Livro _livro = await _livroRepositorio.CriarLivro(livro);
            return Ok(_livro);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Livro>> AtualizarLivro([FromBody] Livro livro, int id)
        {
            Livro _livro = await _livroRepositorio.AtualizarLivro(livro, id);
            return Ok(_livro);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarLivro(int id)
        {
            bool _apagado = await _livroRepositorio.ApagarLivro(id);
            return Ok(_apagado);
        }
    }
}