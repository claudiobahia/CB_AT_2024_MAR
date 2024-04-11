using System.ComponentModel;

namespace LivrariaAT.Enums
{
    public enum PermissaoUsuario
    {
        [Description("Usuário é um editor")]
        Editor = 0,
        [Description("Usuário é um vizualizador")]
        Usuario = 1,

    }
}
