using System.ComponentModel.DataAnnotations;

namespace API_Filmes.DTO
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo Título é Obrigatório")]
        public string Titulo {get;set;}
        
        public string TituloOriginal {get;set;}
        public string Pais {get;set;}       
        public int DiretorId {get;set;}
        [Required(ErrorMessage = "O Ano do filme é Obrigatório")]
        public int Ano {get;set;}
        
        
        [Range(30, 300, ErrorMessage = "O campo Duração deve estar entre 30 e 300 minutos")]        
        public int DuracaoMinutos { get; set; }
        [Range(0.0, 10.0)]
        public decimal RatingIMDB {get;set;}
    }
}