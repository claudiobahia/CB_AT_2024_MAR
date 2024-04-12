using LivrariaAT.Data;
using LivrariaAT.Enums;
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
    public class UsuarioTestes
    {
        [Fact]
        public async Task BuscarTodosUsuarios_DeveRetornarTodosOsUsuarios()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new LivrosDBContex(options))
            {
                context.Usuarios.Add(new Usuario { id = 1, nome = "Usuário 1", email = "usuario1@example.com", password = "password1", permissao = PermissaoUsuario.Usuario, status = StatusUsuario.Pagante, favoritos = new List<string> { "1", "2" } });
                context.Usuarios.Add(new Usuario { id = 2, nome = "Usuário 2", email = "usuario2@example.com", password = "password2", permissao = PermissaoUsuario.Editor, status = StatusUsuario.Devedor, favoritos = new List<string> { "3", "4" } });
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new UsuarioRepositorio(context);

                //Act
                var usuarios = await repositorio.BuscarTodosUsuarios();

                //Assert
                Assert.NotNull(usuarios);
                Assert.Equal(2, usuarios.Count);
            }
        }
    }
}
