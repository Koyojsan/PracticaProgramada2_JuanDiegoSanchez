using Microsoft.EntityFrameworkCore;
using PracticaProgramada2_JuanDiegoSanchez.Models;

namespace PracticaProgramada2_JuanDiegoSanchez.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lista>().HasKey(l => l.IdLista);
            modelBuilder.Entity<Tarea>().HasKey(t => t.IdTarea);
        }
    }
}
