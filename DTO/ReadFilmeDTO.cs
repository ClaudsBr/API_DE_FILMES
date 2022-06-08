using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using API_Filmes.Models;

namespace API_Filmes.DTO
{
    public class ReadFilmeDTO
    {
        [Key]
        [Required]
        public int Id {get;set;}
        [Required(ErrorMessage = "O campo Título é Obrigatório")]
        public string Titulo {get;set;}
        public string TituloOriginal {get;set;}
        public string Pais {get;set;}        
        public Diretor Diretor { get; set; }
        [Required(ErrorMessage = "O Ano do filme é Obrigatório")]
        public int Ano {get;set;}
        public List<Genero> Genero {get;set;}
        [Range(30, 300, ErrorMessage = "O campo Duração deve estar entre 30 e 300 minutos")]        
        public int DuracaoMinutos { get; set; }  
        public DateTime HoraConsulta {get;set;}
        public decimal RatingIMDB {get;set;}
        
        public List<Ator> Atores {get;set;}

        public ReadFilmeDTO(){
            HoraConsulta = DateTime.Now;
            
        }
    }
}