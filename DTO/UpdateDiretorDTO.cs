using System.ComponentModel.DataAnnotations;
using API_Filmes.Models;
using System;
using System.Collections.Generic;

namespace API_Filmes.DTO
{
    public class UpdateDiretorDTO
    {
        [Required]
        public string Nome {get;set;}
        public string Nacionalidade {get;set;}
        public DateTime DataNascimento { get; set; }
        public List<Filme> Trabalhos {get;set;}
    }
}