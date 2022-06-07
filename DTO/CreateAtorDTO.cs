using System.ComponentModel.DataAnnotations;
using System;

namespace API_Filmes.DTO
{
    public class CreateAtorDTO
    {
        [Required]
        public string Nome {get;set;}
        public string Nacionalidade {get;set;}
        public DateTime DataNascimento { get; set; }

    }
}