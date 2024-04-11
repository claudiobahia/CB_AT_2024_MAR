using System.ComponentModel;

namespace LivrariaAT.Enums
{
    public enum StatusUsuario
    {
        [Description("Usuário é um devedor")]
        Devedor = 0,
        [Description("Usuário é um pagante")]
        Pagante = 1,

    }
}
