using System.ComponentModel.DataAnnotations;
using API_Filmes.Models;
using System;
using System.Collections.Generic;


namespace API_Filmes.DTO
{
    public class ReadAtorDTO
    {
        [Key]
        [Required]
        public int Id{get;set;}
        [Required]
        public string Nome {get;set;}
        public string Nacionalidade {get;set;}
        
        public List<Filme> Filmes {get;set;}
        public DateTime HoraConsulta {get;set;}

        public ReadAtorDTO(){
            HoraConsulta = DateTime.Now;
        }
    }
}