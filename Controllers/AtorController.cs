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
    public class AtorController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public AtorController (FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAtor([FromBody] CreateAtorDTO atorDTO){
            Ator ator = _mapper.Map<Ator>(atorDTO);
            _context.Atores.Add(ator);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReturnAtorByID), new {Id = ator.Id}, ator);
        }

        [HttpGet]
        public IActionResult ListAtor(){
            return Ok(_context.Atores);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnAtorByID(int id){
            Ator ator = _context.Atores.FirstOrDefault(a=>a.Id == id);
            if( ator != null){
                ReadAtorDTO atorDTO = _mapper.Map<ReadAtorDTO>(ator);                                

                return Ok(atorDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAtor(int id, [FromBody] UpdateAtorDTO atorDTO){
            Ator ator = _context.Atores.FirstOrDefault(a=>a.Id == id);
            if(ator == null)
            {
                return NotFound();
            }
            _mapper.Map(atorDTO, ator);
                       
           _context.SaveChanges();

           return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAtor(int id){
            Ator ator = _context.Atores.FirstOrDefault(a=>a.Id == id);
            if (ator == null){
                return NotFound();
            }
            _context.Atores.Remove(ator);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost("{id}")]
        public IActionResult AdicionarFilmes(int id, [FromBody] AddFilmeDTO  filmeDTO){
            Ator ator = _context.Atores.FirstOrDefault(a=>a.Id == id);
            if (ator == null){
                return NotFound();
            }
            Filme filme = _context.Filmes.FirstOrDefault(f=>f.Id == filmeDTO.Id);
            if(filme == null){
                return NotFound();
            }
            ator.Filmes.Add(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}