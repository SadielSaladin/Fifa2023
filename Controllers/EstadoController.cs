using Fifa2023.DataContext;
using Fifa2023.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2023.Controllers
{
    public class EstadoController : Controller
    {
        private readonly AplicationDbContext _context;
        public EstadoController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Estado> estados = _context.Estados;
            return View(estados);
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Estado estado)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Add(estado);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    
                }
                RedirectToAction("Index", "Estado");
            }
            return View();
        }
    }
}
