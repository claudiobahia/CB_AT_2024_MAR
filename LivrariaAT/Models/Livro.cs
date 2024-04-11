using System.ComponentModel.DataAnnotations;

namespace LivrariaAT.Models
{
    public class Livro
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; } //sinopsis
        public string autor { get; set; }
        public string ultimaatt { get; set; }
        public string imagem { get; set; }
        
        //public List<Capitulo> capitulos { get; set; }//
    }
}
