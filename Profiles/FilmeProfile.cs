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
                CreateMap<Filme, ReadFilmeDTO>();
                CreateMap<UpdateFilmeDTO, Filme>();
                
            }
        
    }
}