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
    public class HomeController:Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}