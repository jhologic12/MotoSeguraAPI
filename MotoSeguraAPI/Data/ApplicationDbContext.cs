using Microsoft.EntityFrameworkCore;
using MotoSeguraApi.Models.SubModels;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.UbicacionInicio);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.UbicacionFin);

            modelBuilder.Owned<Gps>(); // ✅ Declaración explícita

            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Gps, gps =>
            {
                gps.OwnsOne(g => g.Ubicacion);
            });

            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Acelerometro);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Giroscopio);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.Conectividad);
            modelBuilder.Entity<Trayecto>().OwnsOne(t => t.VerificacionCasco);

            // Relación Trayecto → Eventos
            // Relación Usuario → Trayectos
            modelBuilder.Entity<Trayecto>()
                .HasOne(t => t.User)
                .WithMany(u => u.Trayectos)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            //  Índice único para Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();



        }
    }
}