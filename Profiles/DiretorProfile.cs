using AutoMapper;
using API_Filmes.Models;
using API_Filmes.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Filmes.Profiles
{
    public class DiretorProfile : Profile
    {
        public DiretorProfile ()
        {
            CreateMap<CreateDiretorDTO, Diretor>();
            CreateMap<Diretor, ReadDiretorDTO>().ForMember(diretor => diretor.Filmes, option => option
                .MapFrom(d => d.Filmes.Select(f=> new {f.Titulo})));
                
            CreateMap<UpdateDiretorDTO, Diretor>();
        }
    }
}