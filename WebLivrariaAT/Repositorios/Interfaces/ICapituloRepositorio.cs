using WebLivrariaAT.Models;

namespace WebLivrariaAT.Repositorios.Interfaces
{
    public interface ICapituloRepositorio
    {
        Task<List<CapituloViewModel>> BuscarTodosCapitulos();
        Task<List<CapituloViewModel>> BuscarTodosCapitulosDeLivro(int livroid);
        Task<CapituloViewModel> BuscarCapituloPorId(int id);
        Task<CapituloViewModel> CriarCapitulo(CapituloViewModel capitulo);
        Task<CapituloViewModel> AtualizarCapitulo(CapituloViewModel capitulo, int id);
        Task<bool> ApagarCapitulo(int id);
    }
}
