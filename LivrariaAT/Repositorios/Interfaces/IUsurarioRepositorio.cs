using LivrariaAT.Models;

namespace LivrariaAT.Repositorio.Interfaces
{
    public interface IUsurarioRepositorio
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
        Task<Usuario> BuscarUsuarioPorId(int id);
        Task<Usuario> CriarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario, int id);
        Task<bool> ApagarUsuario(int id);
    }
}
