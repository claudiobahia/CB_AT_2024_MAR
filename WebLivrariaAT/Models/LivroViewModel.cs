using System.ComponentModel.DataAnnotations;

namespace WebLivrariaAT.Models
{
    public class LivroViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; } 
        public string autor { get; set; }
        public string ultimaatt { get; set; }
        public string imagem { get; set; }
    }
}
