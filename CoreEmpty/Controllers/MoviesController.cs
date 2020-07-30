using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreEmpty.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CoreEmpty.Models.MovieContext _context;

        public MoviesController(CoreEmpty.Models.MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Movie.ToList();

            return View(data);
        }
    }
}