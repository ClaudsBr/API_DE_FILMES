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
    public class DiretorController: ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public DiretorController (FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddDiretor([FromBody] CreateDiretorDTO diretorDTO){
            Diretor diretor = _mapper.Map<Diretor>(diretorDTO);
            _context.Diretores.Add(diretor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReturnDiretorByID), new {Id = diretor.Id}, diretor);
        }

        [HttpGet]
        public IActionResult ListAtor(){
            return Ok(_context.Atores);
        }

        [HttpGet("{{id}")]
        public IActionResult ReturnDiretorByID(int id){
            Diretor diretor = _context.Diretores.FirstOrDefault(d=>d.Id == id);
            if( diretor != null){
                ReadDiretorDTO diretorDTO = _mapper.Map<ReadDiretorDTO>(diretor);                                

                return Ok(diretorDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDiretor(int id, [FromBody] UpdateDiretorDTO diretorDTO){
            Diretor diretor = _context.Diretores.FirstOrDefault(d=>d.Id == id);
            if(diretor == null)
            {
                return NotFound();
            }
            _mapper.Map(diretorDTO, diretor);
                       
           _context.SaveChanges();

           return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiretor(int id){
            Diretor diretor = _context.Diretores.FirstOrDefault(d=>d.Id == id);
            if (diretor == null){
                return NotFound();
            }
            _context.Diretores.Remove(diretor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}