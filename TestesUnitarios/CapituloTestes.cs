using LivrariaAT.Data;
using LivrariaAT.Models;
using LivrariaAT.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesUnitarios
{
    public class CapituloTestes
    {
        [Fact]
        public async Task BuscarTodosCapitulos_DeveRetornarTodosOsCapitulos()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new LivrosDBContex(options))
            {
                context.Capitulos.Add(new Capitulo { id = 1, titulo = "Capítulo 1", descricao = "Descrição 1", livroid = 1 });
                context.Capitulos.Add(new Capitulo { id = 2, titulo = "Capítulo 2", descricao = "Descrição 2", livroid = 1 });
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new CapituloRepositorio(context);

                //Act
                var capitulos = await repositorio.BuscarTodosCapitulos();

                //Assert
                Assert.NotNull(capitulos);
                Assert.Equal(2, capitulos.Count);
            }
        }

        [Fact]
        public async Task BuscarTodosCapitulosDeLivro_DeveRetornarCapitulosDoLivro()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new LivrosDBContex(options))
            {
                context.Capitulos.Add(new Capitulo { id = 1, titulo = "Capítulo 1", descricao = "Descrição 1", livroid = 1 });
                context.Capitulos.Add(new Capitulo { id = 2, titulo = "Capítulo 2", descricao = "Descrição 2", livroid = 2 });
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new CapituloRepositorio(context);

                //Act
                var capitulos = await repositorio.BuscarTodosCapitulosDeLivro(1);

                //Assert
                Assert.NotNull(capitulos);
                Assert.Single(capitulos);
                Assert.Equal(1, capitulos.First().id);
            }
        }
    }
}
