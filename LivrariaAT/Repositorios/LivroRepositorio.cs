using LivrariaAT.Data;
using LivrariaAT.Models;
using LivrariaAT.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAT.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly LivrosDBContex _dbContex;
        public LivroRepositorio(LivrosDBContex livrosDBContex)
        {
            _dbContex = livrosDBContex;
        }
        public async Task<bool> ApagarLivro(int id)
        {
            Livro livroPorId = await BuscarLivroPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro para ID: {id} não foi encontrado");
            }
            _dbContex.Livros.Remove(livroPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }

        public async Task<Livro> AtualizarLivro(Livro livro, int id)
        {
            Livro livroPorId = await BuscarLivroPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro para ID: {id} não foi encontrado");
            }
            livroPorId.nome = livro.nome;
            livroPorId.autor = livro.autor;
            livroPorId.ultimaatt = livro.ultimaatt;
            livroPorId.descricao = livro.descricao;
            livroPorId.imagem = livro.imagem;
            _dbContex.Update(livroPorId);
            await _dbContex.SaveChangesAsync();

            return livroPorId;
        }

        public async Task<Livro> BuscarLivroPorId(int id)
        {
            return await _dbContex.Livros.FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<List<Livro>> BuscarTodosLivros()
        {
            return await _dbContex.Livros.ToListAsync();
        }

        public async Task<Livro> CriarLivro(Livro livro)
        {
            await _dbContex.Livros.AddAsync(livro);
            await _dbContex.SaveChangesAsync();
            return livro;

        }
    }
}
