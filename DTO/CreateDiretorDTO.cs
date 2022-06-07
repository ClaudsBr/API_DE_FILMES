using System.ComponentModel.DataAnnotations;
using System;

namespace API_Filmes.DTO
{
    public class CreateDiretorDTO
    {
        [Required]
        public string Nome {get;set;}
        public string Nacionalidade {get;set;}
        
    }
}