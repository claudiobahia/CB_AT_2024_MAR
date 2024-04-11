using LivrariaAT.Data;
using LivrariaAT.Models;
using LivrariaAT.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAT.Repositorios
{
    public class CapituloRepositorio : ICapituloRepositorio
    {
        private readonly LivrosDBContex _dbContex;
        public CapituloRepositorio(LivrosDBContex livrosDBContex)
        {
            _dbContex = livrosDBContex;
        }
        public async Task<bool> ApagarCapitulo(int id)
        {
            Capitulo capituloPorId = await BuscarCapituloPorId(id);
            if (capituloPorId == null)
            {
                throw new Exception($"Capitulo para ID: {id} não foi encontrado");
            }
            _dbContex.Capitulos.Remove(capituloPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }

        public async Task<Capitulo> AtualizarCapitulo(Capitulo capitulo, int id)
        {
            Capitulo capituloPorId = await BuscarCapituloPorId(id);
            if (capituloPorId == null)
            {
                throw new Exception($"Capitulo para ID: {id} não foi encontrado");
            }
            capituloPorId.titulo = capitulo.titulo;
            capituloPorId.descricao = capitulo.descricao;
            capituloPorId.livroid = capitulo.livroid;

            return capituloPorId;
        }

        public async Task<Capitulo> BuscarCapituloPorId(int id)
        {
            return await _dbContex.Capitulos.FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<List<Capitulo>> BuscarTodosCapitulos()
        {
            return await _dbContex.Capitulos.ToListAsync();
        }
        public async Task<List<Capitulo>> BuscarTodosCapitulosDeLivro(int livroid)
        {
            return await _dbContex.Capitulos.Where(c => c.livroid == livroid).ToListAsync();
        }

        public async Task<Capitulo> CriarCapitulo(Capitulo capitulo)
        {
            await _dbContex.Capitulos.AddAsync(capitulo);
            await _dbContex.SaveChangesAsync();
            return capitulo;

        }
    }
}
