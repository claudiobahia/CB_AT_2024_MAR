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
        [Fact]
        public async Task BuscarUsuarioPorId_DeveRetornarUsuario()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            Usuario usuario = new Usuario { id = 1, nome = "Usuário 1", email = "usuario1@example.com", password = "password1", permissao = PermissaoUsuario.Usuario, status = StatusUsuario.Pagante, favoritos = new List<string> { "1", "2" } };

            using (var context = new LivrosDBContex(options))
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new UsuarioRepositorio(context);

                //Act
                Usuario usuarioResp = await repositorio.BuscarUsuarioPorId(usuario.id);

                //Assert
                Assert.NotNull(usuarioResp);
            }
        }

        [Fact]
        public async Task ApagarUsuarioPorId_DeveRetornarTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            Usuario usuario = new Usuario { id = 1, nome = "Usuário 1", email = "usuario1@example.com", password = "password1", permissao = PermissaoUsuario.Usuario, status = StatusUsuario.Pagante, favoritos = new List<string> { "1", "2" } };

            using (var context = new LivrosDBContex(options))
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new UsuarioRepositorio(context);

                //Act
                bool usuarioResp = await repositorio.ApagarUsuario(usuario.id);

                //Assert
                Assert.True(usuarioResp);
            }
        }
        [Fact]
        public async Task AtualizarUsuarioPorId_DeveRetornarUsuarioAtualizado()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<LivrosDBContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            Usuario usuario1 = new Usuario { id = 1, nome = "Usuário 1", email = "usuario1@example.com", password = "password1", permissao = PermissaoUsuario.Usuario, status = StatusUsuario.Pagante, favoritos = new List<string> { "1", "2" } };
            Usuario usuario2 = new Usuario { id = 2, nome = "Usuário 2", email = "usuario2@example.com", password = "password2", permissao = PermissaoUsuario.Usuario, status = StatusUsuario.Pagante, favoritos = new List<string> { "3", "4" } };

            using (var context = new LivrosDBContex(options))
            {
                context.Usuarios.Add(usuario1);
                context.SaveChanges();
            }

            using (var context = new LivrosDBContex(options))
            {
                var repositorio = new UsuarioRepositorio(context);

                //Act
                var usuarioResp = await repositorio.AtualizarUsuario(usuario2,usuario1.id);

                //Assert
                Assert.NotNull(usuarioResp);
                Assert.Equal(usuario2,usuario1);
            }
        }
    }
}
