using AutoMapper;
using API_Filmes.Models;
using API_Filmes.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Filmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
            {
                CreateMap<CreateFilmeDTO, Filme>();
                CreateMap<Filme, ReadFilmeDTO>().ForMember(filme => filme.Atores, option => option
                .MapFrom(f => f.Atores.Select(a=> new {a.Nome})))
                .ForMember(filme => filme.Genero, option => option.MapFrom(f => f.Genero.Select(g=> new {g.Nome})));                
                CreateMap<UpdateFilmeDTO, Filme>();
                
            }
        
    }
}