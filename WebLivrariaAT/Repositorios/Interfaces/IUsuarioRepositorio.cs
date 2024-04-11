using WebLivrariaAT.Models;

namespace WebLivrariaAT.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioViewModel>> BuscarTodosUsuarios();
        Task<UsuarioViewModel> BuscarUsuarioPorId(int id);
        Task<UsuarioViewModel> CriarUsuario(UsuarioViewModel usuario);
        Task<UsuarioViewModel> AtualizarUsuario(UsuarioViewModel usuario, int id);
        Task<bool> ApagarUsuario(int id);
    }
}
