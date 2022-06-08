using System;
using API_Filmes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_Filmes.Data;
using API_Filmes.DTO;
using AutoMapper;

namespace API_Filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            

            Filme filme = _mapper.Map<Filme>(filmeDTO);
            
            
           _context.Filmes.Add(filme);
           
            filme.RatingIMDB = Math.Round(filmeDTO.RatingIMDB,1);
           _context.SaveChanges();
            //Mostra alem do status da requisição aonde este recurso foi criado
            return CreatedAtAction(nameof(ReturnFilmeByID), new {Id = filme.Id}, filme);         
        }

        [HttpGet]
        public IActionResult ListFilmes(){
             

            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnFilmeByID(int id){
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null){
                ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
                                

                return Ok(filmeDTO);
            }

            return NotFound();
        }

        /*[HttpGet("diretor/{diretor}")]
        public IActionResult ReturnFilmeByDirector(string diretor){
            List<Filme> filmesDiretor = new List<Filme>();
            foreach (Filme filme in _context.Filmes)
            {
                if(filme.Diretor.Contains(diretor)){
                    filmesDiretor.Add(filme);
                }
            }         
            
            if(filmesDiretor != null){
                return Ok(filmesDiretor);
            }
            return NotFound("Não há filmes desse diretor no catalogo");
        }

        [HttpGet("ano/{ano}")]
        public IActionResult ReturnFilmeByAno(int ano){
            List<Filme> filmesDesseAno = new List<Filme>();
            foreach( Filme filme in _context.Filmes){
                if (filme.Ano == ano){
                    filmesDesseAno.Add(filme);                    
                }
            }
            if (filmesDesseAno != null){
                return Ok(filmesDesseAno);
            }
            return NotFound();
        }*/

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id){
            
            Filme filme = _context.Filmes.FirstOrDefault(f=> f.Id == id);
            if(filme == null){
                return NotFound("Filme não Encontrado");
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent(); // BOA PRATICA este tipo de retorno após uma deleção
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id,[FromBody] UpdateFilmeDTO filmeDTO){
            Filme filme = _context.Filmes.FirstOrDefault(f=>f.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDTO, filme);
                       
           _context.SaveChanges();

           return NoContent();
        }

        [HttpPost("adicionar/ator/{id}")]
        public IActionResult FormandoElenco(int id, [FromBody] AddFilmeDTO filmeDTO){
            Filme filme = _context.Filmes.FirstOrDefault(f=>f.Id == filmeDTO.Id);
            if(filme == null){
                return NotFound("Filme não encontrado");
            }
            Ator ator = _context.Atores.FirstOrDefault(a=>a.Id == id);
            if(ator == null){
                return NotFound("Ator não Encontrado");
            }
            filme.Atores.Add(ator);
            return NoContent();
        }
    }
}