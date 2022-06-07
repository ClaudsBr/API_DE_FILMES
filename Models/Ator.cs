using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Filmes.Models
{
    public class Ator
    {
        [Key]
        [Required]
        public int Id{get;set;}
        [Required]
        public string Nome {get;set;}
        public string Nacionalidade {get;set;}        
        public virtual List<Filme> Trabalhos {get;set;}
        
        
    }
}