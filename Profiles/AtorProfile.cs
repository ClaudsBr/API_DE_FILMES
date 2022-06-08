using AutoMapper;
using API_Filmes.Models;
using API_Filmes.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Filmes.Profiles
{
    public class AtorProfile : Profile
    {
        public AtorProfile ()
        {
            CreateMap<CreateAtorDTO, Ator>();
            CreateMap<Ator, ReadAtorDTO>().ForMember(ator => ator.Filmes, option => option
                .MapFrom(a => a.Filmes.Select(f=> new {f.Titulo})));
            CreateMap<UpdateAtorDTO, Ator>();
        }
    }
}