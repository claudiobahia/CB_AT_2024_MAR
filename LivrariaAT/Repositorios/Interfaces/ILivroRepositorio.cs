using LivrariaAT.Models;

namespace LivrariaAT.Repositorios.Interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<Livro>> BuscarTodosLivros();
        Task<Livro> BuscarLivroPorId(int id);
        Task<Livro> CriarLivro(Livro livro);
        Task<Livro> AtualizarLivro(Livro livro, int id);
        Task<bool> ApagarLivro(int id);
    }
}
