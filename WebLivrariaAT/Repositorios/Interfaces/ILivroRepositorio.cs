using WebLivrariaAT.Models;

namespace WebLivrariaAT.Repositorios.Interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<LivroViewModel>> BuscarTodosLivros();
        Task<LivroViewModel> BuscarLivroPorId(int id);
        Task<LivroViewModel> CriarLivro(LivroViewModel livro);
        Task<LivroViewModel> AtualizarLivro(LivroViewModel livro, int id);
        Task<bool> ApagarLivro(int id);
    }
}
