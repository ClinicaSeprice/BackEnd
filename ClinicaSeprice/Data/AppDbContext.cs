using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<PersonaRol> PersonaRoles { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos entre Persona y Direccion
            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.Persona)
                .WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.IdPersona);

            // Relación muchos a muchos entre Persona y Rol
            modelBuilder.Entity<PersonaRol>()
                .HasKey(pr => new { pr.IdPersona, pr.IdRol });

            modelBuilder.Entity<PersonaRol>()
                .HasOne(pr => pr.Persona)
                .WithMany(p => p.PersonaRoles)
                .HasForeignKey(pr => pr.IdPersona);

            modelBuilder.Entity<PersonaRol>()
                .HasOne(pr => pr.Rol)
                .WithMany(r => r.PersonaRoles)
                .HasForeignKey(pr => pr.IdRol);

            // Relación uno a uno entre Persona y Medico
            modelBuilder.Entity<Medico>()
                .HasOne(m => m.Persona)
                .WithOne(p => p.Medico)
                .HasForeignKey<Medico>(m => m.IdPersona);

            // Relación uno a uno entre Persona y Personal
            modelBuilder.Entity<Personal>()
                .HasOne(pe => pe.Persona)
                .WithOne(p => p.Personal)
                .HasForeignKey<Personal>(pe => pe.IdPersona);

            // Relación uno a uno entre Persona y Usuario
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(u => u.IdPersona)
                .OnDelete(DeleteBehavior.SetNull);  

            // Relación uno a uno entre Persona y HistoriaClinica
            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(h => h.Persona)
                .WithOne(p => p.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(h => h.IdPersona);
        }

    }
}
