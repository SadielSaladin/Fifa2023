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
    public class EquiposController : Controller
    {
        private readonly AplicationDbContext _context;
        public EquiposController(AplicationDbContext aplicationDbContext)
        {
            _context = aplicationDbContext;
        }
        public IActionResult Index()
        {
            //List<Jugador> jugadores = _context.Jugadores.ToList();
            IEnumerable<Equipo> equipos = _context.Equipos.Include(j => j.Lista_jugadores);
          ///Buscar una manera para que por cada equipo aparesca sus jugadores

            return View(equipos);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Equipo equipo )

        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Editar(int? id)
        {
        
            if (id != null && id != 0) { Equipo equipo = _context.Equipos.Where(i => i.Id == id).Single(); return View(equipo); }
            return View();

        }
        [HttpPost]
        public IActionResult Editar(Equipo equipo)
        {
            try
            {
                _context.Update(equipo);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Eliminar(int? id)
        {


            Equipo equipo = _context.Equipos.Where(i => i.Id == id).Single();
            return View(equipo);
        }





        [HttpPost]
        public IActionResult Eliminar(Equipo equipo)
        {
            try
            {
                _context.Equipos.Remove(equipo);
                _context.SaveChanges();
                RedirectToAction("Index");
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");



        }
    }
}
