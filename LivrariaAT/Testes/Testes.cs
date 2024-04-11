using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Repositorios.Interfaces;

namespace LivrariaAT.Testes
{
    public class Testes
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IUsurarioRepositorio _usuarioRepositorio;
        private readonly ICapituloRepositorio _capituloRepositorio;
        public Testes(ILivroRepositorio livroRepositorio,
                        IUsurarioRepositorio usuarioRepositorio,
                        ICapituloRepositorio capituloRepositorio) {
            _livroRepositorio = livroRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _capituloRepositorio = capituloRepositorio;
        }

    }
}
