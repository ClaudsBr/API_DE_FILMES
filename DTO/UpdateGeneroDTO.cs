using System.ComponentModel.DataAnnotations;
using API_Filmes.Models;
using System;
using System.Collections.Generic;

namespace API_Filmes.DTO
{
    public class UpdateGeneroDTO
    {
        [Required]
        public string Nome {get;set;}
    }
}