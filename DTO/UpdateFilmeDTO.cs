using System.ComponentModel.DataAnnotations;

namespace API_Filmes.DTO
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage = "O campo Título é Obrigatório")]
        public string Titulo {get;set;}
        [Required(ErrorMessage = "O campo Diretor é Obrigatório")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O Ano do filme é Obrigatório")]
        public int Ano {get;set;}
        [Required(ErrorMessage = "O campo Gênero é Obrigatório")]
        public string Genero { get; set; }
        [Range(30, 300, ErrorMessage = "O campo Duração deve estar entre 30 e 300 minutos")]        
        public int DuracaoMinutos { get; set; }
    }
}