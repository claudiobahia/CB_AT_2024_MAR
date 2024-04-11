using LivrariaAT.Models;
using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsurarioRepositorio _usurarioRepositorio;

        public UsuarioController(IUsurarioRepositorio usurarioRepositorio)
        {
            _usurarioRepositorio = usurarioRepositorio;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> _usuarios = await _usurarioRepositorio.BuscarTodosUsuarios();
            return Ok(_usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarUsuarioPorId(int id)
        {
            Usuario _usuario = await _usurarioRepositorio.BuscarUsuarioPorId(id);
            return Ok(_usuario);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Usuario>> CriarUsuario([FromBody] Usuario usuario)
        {
            Usuario _usuario = await _usurarioRepositorio.CriarUsuario(usuario);
            return Ok(_usuario);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> AtualizarUsuario([FromBody] Usuario usuario, int id)
        {
            Usuario _usuario = await _usurarioRepositorio.AtualizarUsuario(usuario, id);
            return Ok(_usuario);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarUsuario(int id)
        {
            bool _apagado = await _usurarioRepositorio.ApagarUsuario(id);
            return Ok(_apagado);
        }
    }
}