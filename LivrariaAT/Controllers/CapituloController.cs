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
    public class CapituloController : ControllerBase
    {
        private readonly ICapituloRepositorio _capituloRepositorio;

        public CapituloController(ICapituloRepositorio capituloRepositorio)
        {
            _capituloRepositorio = capituloRepositorio;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Capitulo>>> BuscarTodosCapitulos()
        {
            List<Capitulo> _capitulos = await _capituloRepositorio.BuscarTodosCapitulos();
            return Ok(_capitulos);
        }
        //[Authorize]
        [HttpGet("{livroid}")]
        public async Task<ActionResult<List<Capitulo>>> BuscarTodosCapitulosDeLivro(int livroid)
        {
            List<Capitulo> _capitulos = await _capituloRepositorio.BuscarTodosCapitulosDeLivro(livroid);
            return Ok(_capitulos);
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Capitulo>> BuscarCapituloPorId(int id)
        //{
        //    Capitulo _capitulo = await _capituloRepositorio.BuscarCapituloPorId(id);
        //    return Ok(_capitulo);
        //}

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Capitulo>> CriarCapitulo([FromBody] Capitulo capitulo)
        {
            Capitulo _capitulo = await _capituloRepositorio.CriarCapitulo(capitulo);
            return Ok(_capitulo);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Capitulo>> AtualizarCapitulo([FromBody] Capitulo capitulo, int id)
        {
            Capitulo _capitulo = await _capituloRepositorio.AtualizarCapitulo(capitulo, id);
            return Ok(_capitulo);
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarCapitulo(int id)
        {
            bool _apagado = await _capituloRepositorio.ApagarCapitulo(id);
            return Ok(_apagado);
        }
    }
}