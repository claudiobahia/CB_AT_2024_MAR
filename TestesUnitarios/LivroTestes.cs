using LivrariaAT.Models;
using LivrariaAT.Data;
using Microsoft.EntityFrameworkCore;
using LivrariaAT.Repositorios;

namespace TestesUnitarios
{
    public class LivroTestes
    {
        [Fact]
        public async Task BuscarTodosLivros_DeveRetornarTodosOsLivros()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new LivrosDBContex(options))
            {
                context.Livros.Add(new Livro { id = 1, nome = "Livro 1", descricao = "Descrição 1", autor = "Autor 1", ultimaatt = "01/01/20277", imagem = "imagem1.jpg" });
                context.Livros.Add(new Livro { id = 2, nome = "Livro 2", descricao = "Descrição 2", autor = "Autor 2", ultimaatt = "02/02/2026", imagem = "imagem2.jpg" });
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new LivroRepositorio(context);

                //Act
                var livros = await repositorio.BuscarTodosLivros();

                //Assert
                Assert.NotNull(livros);
                Assert.Equal(2, livros.Count);
            }
        }
        [Fact]
        public async Task BuscarLivroPorId_DeveRetornarLivro()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            var livro = new Livro { id = 1, nome = "Livro 1", descricao = "Descrição 1", autor = "Autor 1", ultimaatt = "01/01/20277", imagem = "imagem1.jpg" };
            using (var context = new LivrosDBContex(options))
            {
                context.Livros.Add(livro);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new LivroRepositorio(context);

                //Act
                var livros = await repositorio.BuscarLivroPorId(livro.id);

                //Assert
                Assert.NotNull(livro);
            }
        }

        [Fact]
        public async Task AtualizarLivroPorId_DeveRetornarLivroAtualizado()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;


            var livro1 = new Livro { id = 1, nome = "Livro 1", descricao = "Descrição 1", autor = "Autor 1", ultimaatt = "01/01/20277", imagem = "imagem1.jpg" };
            var livro2 = new Livro { id = 1, nome = "Livro 2", descricao = "Descrição 2", autor = "Autor 2", ultimaatt = "01/01/2027", imagem = "imagem2.jpg" };

            using (var context = new LivrosDBContex(options))
            {
                context.Livros.Add(livro1);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new LivroRepositorio(context);

                //Act
                var livroResp = await repositorio.AtualizarLivro(livro2, livro1.id);

                //Assert
                Assert.NotNull(livroResp);
                Assert.Equal(livro2, livroResp);
            }
        }

        [Fact]
        public async Task ÁpagarLivroPorId_DeveRetornarTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;


            var livro1 = new Livro { id = 1, nome = "Livro 1", descricao = "Descrição 1", autor = "Autor 1", ultimaatt = "01/01/20277", imagem = "imagem1.jpg" };

            using (var context = new LivrosDBContex(options))
            {
                context.Livros.Add(livro1);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new LivroRepositorio(context);

                //Act
                var livroResp = await repositorio.ApagarLivro(livro1.id);

                //Assert
                Assert.True(livroResp);
            }
        }

    }
}