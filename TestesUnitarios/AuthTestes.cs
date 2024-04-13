using Microsoft.AspNetCore.Mvc;
using LivrariaAT.Controllers;
using LivrariaAT.Models;
using LivrariaAT.Repositorio.Interfaces;
using Moq;

namespace SeuNamespace.Testes
{
    public class AuthTestes
    {
        [Fact]
        public async Task Auth_DeveRetornarOkQuandoLoginESenhaCorretos()
        {
            // Arrange
            var usuarioRepositorioMock = new Mock<IUsurarioRepositorio>();
            usuarioRepositorioMock.Setup(repo => repo.BuscarTodosUsuarios()).ReturnsAsync(new List<Usuario>
            {
                new Usuario { id = 1, email = "usuario1@example.com", password = "senha1" },
                new Usuario { id = 2, email = "usuario2@example.com", password = "senha2" }
            });

            var authController = new AuthController(usuarioRepositorioMock.Object);

            // Act
            var resultado = await authController.Auth("usuario1@example.com", "senha1") as OkObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(200, resultado.StatusCode);
        }

        [Fact]
        public async Task Auth_DeveRetornarBadRequestQuandoLoginOuSenhaInvalidos()
        {
            // Arrange
            var usuarioRepositorioMock = new Mock<IUsurarioRepositorio>();
            usuarioRepositorioMock.Setup(repo => repo.BuscarTodosUsuarios()).ReturnsAsync(new List<Usuario>
            {
                new Usuario { id = 1, email = "usuario1@example.com", password = "senha1" },
                new Usuario { id = 2, email = "usuario2@example.com", password = "senha2" }
            });

            var authController = new AuthController(usuarioRepositorioMock.Object);

            // Act
            var resultado = await authController.Auth("usuario1@example.com", "senha2") as BadRequestObjectResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(400, resultado.StatusCode);
            Assert.Equal("login ou senha invalidos", resultado.Value);
        }
    }
}
