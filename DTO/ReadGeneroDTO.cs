using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using API_Filmes.Models;

namespace API_Filmes.DTO
{
    public class ReadGeneroDTO
    {
        public int Id {get;set;}
        [Required]
        public string Nome {get;set;}
        public DateTime HoraConsulta {get;set;}

        public ReadGeneroDTO(){
            HoraConsulta = DateTime.Now;
        }
    }
}