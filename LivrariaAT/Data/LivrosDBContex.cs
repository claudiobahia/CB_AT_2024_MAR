using LivrariaAT.Data.Map;
using LivrariaAT.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAT.Data
{
    public class LivrosDBContex : DbContext
    {
        public LivrosDBContex(DbContextOptions<LivrosDBContex> options) 
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Livro> Livros {  get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new CapituloMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
