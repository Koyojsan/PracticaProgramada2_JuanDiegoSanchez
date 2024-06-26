using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_JuanDiegoSanchez.AppDbContext;
using PracticaProgramada2_JuanDiegoSanchez.Models;

namespace PracticaProgramada2_JuanDiegoSanchez.Controllers
{
    public class LoguearController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoguearController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            Usuario User = new Usuario()
            {
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Contrasena = usuario.Contrasena
            };

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            if (usuario.Id != 0)
            {
                return RedirectToAction("Login", "Loguear");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login usuario)
        {
            Usuario? user = await _context.Usuarios.Where(u => u.Email == usuario.Email && u.Contrasena == usuario.Contrasena).FirstOrDefaultAsync();

 
            if (user != null)
            {
                //Estos son del inicio de sesión, es para guardar estos datos y mantenerme registrado, estos funcionan por lo que implementé en Program.cs
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.Nombre);
                HttpContext.Session.SetString("UserEmail", user.Email);

                return RedirectToAction("Index", "Usuarios");
            }
            else 
            {
                return View();
            }
        }
    }
}
