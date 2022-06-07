using System.ComponentModel.DataAnnotations;

namespace API_Filmes.Models
{
    public class Genero
    {
        public int Id {get;set;}
        [Required]
        public string Nome {get;set;}
    }
}