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
    public class GeneroController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public GeneroController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddGenero([FromBody] CreateGeneroDTO generoDTO){
            Genero genero = _mapper.Map<Genero>(generoDTO);
            _context.Generos.Add(genero);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReturnGeneroByID), new {Id = genero.Id}, genero);
        }

        [HttpGet]
        public IActionResult ListGenero(){
            return Ok(_context.Generos);
        }

        [HttpGet("{id}")]
        public IActionResult ReturnGeneroByID(int id){
            Genero genero = _context.Generos.FirstOrDefault(g=>g.Id == id);
            if(genero != null ){
                ReadGeneroDTO generoDTO = _mapper.Map<ReadGeneroDTO>(genero);

                return Ok(generoDTO);
            }

            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteGenero(int id){
            Genero genero = _context.Generos.FirstOrDefault(g=>g.Id == id);
            if( genero == null){
                return NotFound();
            }
            _context.Generos.Remove(genero);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenero(int id, [FromBody] UpdateGeneroDTO generoDTO){
            Genero genero = _context.Generos.FirstOrDefault(g=> g.Id == id);
            if (genero == null){
                return NotFound();
            }
            _mapper.Map(generoDTO, genero);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("adicionar/{id}")]
        public IActionResult AdicionarGeneroEmFilme(int id, [FromBody]AddFilmeDTO filmeDTO){
            Genero genero = _context.Generos.FirstOrDefault(g=> g.Id == id);
            if(genero == null){
                return NotFound();
            }
            Filme filme = _context.Filmes.FirstOrDefault(f=>f.Id == filmeDTO.Id);
            if (filme == null){
                return NotFound();                
            }
            filme.Genero.Add(genero);
            _context.SaveChanges();
            return NoContent();
        }
    }
}