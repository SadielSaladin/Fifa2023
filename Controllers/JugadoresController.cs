using Fifa2023.DataContext;
using Fifa2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2023.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly AplicationDbContext _context;

        public JugadoresController(AplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            //var Data = _context.Jugadores.Include(e => e.Estado).Include(e => e.Equipo);
            IEnumerable<Jugador> jugadores = _context.Jugadores.Include(e => e.Estado).Include(t => t.Equipo);//Tengo que verificar si necesito usar el include aqui o que hacer
            return View(jugadores);
        }

        public IActionResult Crear()
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Nombre_estado");
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Editar(int? id)
        {
            ViewData["EstadoId"] = new SelectList(_context.Estados, "Id", "Nombre_estado");
            ViewData["EquipoId"] = new SelectList(_context.Equipos, "Id", "Nombre");
            if (id != null && id != 0) { Jugador jugador = _context.Jugadores.Where(i => i.Id == id).Single(); return View(jugador); }
            return View();
            
        }
        [HttpPost]
        public IActionResult Editar(Jugador jugador)
        {
            try
            {
                _context.Update(jugador);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Eliminar(int? id)
        {


            Jugador jugador = _context.Jugadores.Where(i => i.Id == id).Single();
            return View(jugador);
        }

       



        [HttpPost]
        public IActionResult Eliminar(Jugador jugador)
        {
            try  { 
                  _context.Jugadores.Remove(jugador);
                  _context.SaveChanges();
                RedirectToAction("Index");
                  }
            catch(Exception ex)
            {
                
            }

            return RedirectToAction("Index");



        }
    }
}

