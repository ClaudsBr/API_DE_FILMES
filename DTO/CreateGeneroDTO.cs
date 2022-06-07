using System.ComponentModel.DataAnnotations;
using System;

namespace API_Filmes.DTO
{
    public class CreateGeneroDTO
    {
        [Required]
        public string Nome {get;set;}
    }
}