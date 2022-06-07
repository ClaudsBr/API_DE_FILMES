using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_Filmes.Models;

namespace API_Filmes.Data
{
    public class FilmeContext: DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options){}

        public DbSet<Filme> Filmes {get;set;}
    }
}