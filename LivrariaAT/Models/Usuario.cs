using LivrariaAT.Enums;

namespace LivrariaAT.Models
{
    public class Usuario
    {
        public Usuario() { }/////////
        public int id { get; set; }
        public PermissaoUsuario permissao { get; set; } // 0 = Editor ; 1 = Usuário
        public string nome { get; set; }
        public string email { get; set; } 
        public string password { get; set; }    //mudar pra senha no futuro kkkkkkk ATT
        public StatusUsuario status { get; set; } //0 = Devedor ; 1 = Pagante
        
        public List<string> favoritos { get; set; } // livros ids
    }
}
