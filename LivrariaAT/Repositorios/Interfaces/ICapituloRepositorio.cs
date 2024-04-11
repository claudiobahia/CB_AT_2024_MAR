using LivrariaAT.Models;

namespace LivrariaAT.Repositorios.Interfaces
{
    public interface ICapituloRepositorio
    {
        Task<List<Capitulo>> BuscarTodosCapitulos();
        Task<List<Capitulo>> BuscarTodosCapitulosDeLivro(int livroid);
        Task<Capitulo> BuscarCapituloPorId(int id);
        Task<Capitulo> CriarCapitulo(Capitulo capitulo);
        Task<Capitulo> AtualizarCapitulo(Capitulo capitulo, int id);
        Task<bool> ApagarCapitulo(int id);
    }
}
