using Microsoft.EntityFrameworkCore;
using MotoSeguraAPI.Models;

namespace MotoSeguraAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trayecto> Trayectos { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        // Opcional: si quieres mapear submodelos complejos como objetos embebidos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.UbicacionInicio);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.UbicacionFin);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Gps);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Acelerometro);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Giroscopio);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Conectividad);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.VerificacionCasco);
        }


    }
}