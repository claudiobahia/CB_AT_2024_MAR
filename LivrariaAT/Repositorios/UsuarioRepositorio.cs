using LivrariaAT.Data;
using LivrariaAT.Models;
using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAT.Repositorios
{
    public class UsuarioRepositorio : IUsurarioRepositorio
    {
        private readonly LivrosDBContex _dbContex;
        public UsuarioRepositorio(LivrosDBContex livrosDBContex)
        {
            _dbContex = livrosDBContex;
        }
        public async Task<bool> ApagarUsuario(int id)
        {
            Usuario usuarioPorId = await BuscarUsuarioPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID: {id} não foi encontrado");
            }
            _dbContex.Usuarios.Remove(usuarioPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarUsuarioPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para ID: {id} não foi encontrado");
            }
            usuarioPorId.permissao = usuario.permissao;
            usuarioPorId.nome = usuario.nome;
            usuarioPorId.email = usuario.email;
            usuarioPorId.status = usuario.status;
            
            usuarioPorId.favoritos = usuario.favoritos;

            return usuarioPorId;
        }

        public async Task<Usuario> BuscarUsuarioPorId(int id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }

        public async Task<Usuario> CriarUsuario(Usuario usuario)
        {
            await _dbContex.Usuarios.AddAsync(usuario);
            await _dbContex.SaveChangesAsync();
            return usuario;
        }
    }
}
