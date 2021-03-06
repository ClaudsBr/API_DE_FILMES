using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace API_Filmes.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id {get;set;}
        [Required(ErrorMessage = "O campo Título é Obrigatório")]
        public string Titulo {get;set;}
        // public string TituloOriginal {get;set;}
        [Required(ErrorMessage = "O campo Diretor é Obrigatório")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O Ano do filme é Obrigatório")]
        public int Ano {get;set;}
        [Required(ErrorMessage = "O campo Gênero é Obrigatório")]
        public string Genero { get; set; }
        [Range(30, 300, ErrorMessage = "O campo Duração deve estar entre 30 e 300 minutos")]        
        public int DuracaoMinutos { get; set; }  
        //public decimal RatingIMDB {get;set;}  
        //public List<Ator> Elenco {get;set;} 
        
        
        
        
    }
}