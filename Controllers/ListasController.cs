using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_JuanDiegoSanchez.AppDbContext;
using PracticaProgramada2_JuanDiegoSanchez.Models;

namespace PracticaProgramada2_JuanDiegoSanchez.Controllers
{
    public class ListasController : Controller
    {
        private readonly ApplicationDbContext _context;


        public ListasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Listas
        public async Task<IActionResult> Index()
        {
            // Este codigo es para dar a entender al programa que para usar las listas, tenemos que estar ingresados con el Usuario que hicimos en el inicio de sesion
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Loguear");
            }

            if (!int.TryParse(userId, out int convertir))
            {
                // Esto es por si UserId no funciona
                return BadRequest("UserId no es un número válido.");
            }

            var listas = await _context.Listas.Where(l => l.IdUsuario == convertir).ToListAsync();

            return View(listas);


        }

        // GET: Listas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // GET: Listas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLista,IdUsuario,Nombre,Descripcion,Imagen")] Lista lista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        // GET: Listas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas.FindAsync(id);
            if (lista == null)
            {
                return NotFound();
            }
            return View(lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLista,IdUsuario,Nombre,Descripcion,Imagen")] Lista lista)
        {
            if (id != lista.IdLista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaExists(lista.IdLista))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lista);
        }

        // GET: Listas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lista = await _context.Listas
                .FirstOrDefaultAsync(m => m.IdLista == id);
            if (lista == null)
            {
                return NotFound();
            }

            return View(lista);
        }

        // POST: Listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lista = await _context.Listas.FindAsync(id);
            if (lista != null)
            {
                _context.Listas.Remove(lista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaExists(int id)
        {
            return _context.Listas.Any(e => e.IdLista == id);
        }
    }
}
