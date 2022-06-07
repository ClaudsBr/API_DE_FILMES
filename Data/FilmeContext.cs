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

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Filme>().HasOne(filme => filme.Diretor).WithMany(diretor => diretor.Trabalhos);
            builder.Entity<Filme>().HasMany(filme => filme.Genero);

        }

        public DbSet<Filme> Filmes {get;set;}
        public DbSet<Ator> Atores {get;set;}
        public DbSet<Diretor> Diretores {get;set;}
        public DbSet<Genero> Generos {get;set;}
    }
}