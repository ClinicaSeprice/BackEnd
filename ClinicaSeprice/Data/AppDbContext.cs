using ClinicaSepriceAPI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public DbSet<HorarioDisponible> HorariosDisponibles { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<ObraSocial> ObrasSociales { get; set; }
        public DbSet<PlanObraSocial> PlanesObraSocial { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<PorcentajePagoMedico> PorcentajesPagoMedicos { get; set; }
        public DbSet<LiquidacionMedico> LiquidacionesMedicos { get; set; }
        public DbSet<DetalleLiquidacionMedico> DetallesLiquidacionesMedicos { get; set; }

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

            // Relación uno a muchos entre Medico y HorarioDisponible
            modelBuilder.Entity<HorarioDisponible>()
                .HasOne(h => h.Medico)
                .WithMany(m => m.HorariosDisponibles)
                .HasForeignKey(h => h.IdMedico);

            // Relación uno a muchos entre HorarioDisponible y Turno
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.HorarioDisponible)
                .WithMany(h => h.Turnos)
                .HasForeignKey(t => t.IdHorario);

            // Relación uno a muchos entre Medico y Turno
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany(m => m.Turnos)
                .HasForeignKey(t => t.IdMedico);

            // Relación uno a muchos entre Persona (Paciente) y Turno
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Persona)
                .WithMany(p => p.Turnos)
                .HasForeignKey(t => t.IdPersona);

            // Relación uno a muchos entre ObraSocial y PlanObraSocial
            modelBuilder.Entity<PlanObraSocial>()
                .HasOne(p => p.ObraSocial)
                .WithMany(o => o.Planes)
                .HasForeignKey(p => p.IdObraSocial);

            // Relación uno a muchos entre Turno y Pago
            modelBuilder.Entity<Factura>()
                .HasOne(p => p.Turno)
                .WithMany(t => t.Facturas)
                .HasForeignKey(p => p.IdTurno);

            // Relación entre Pago y PlanObraSocial
            modelBuilder.Entity<Factura>()
                .HasOne(p => p.PlanObraSocial)
                .WithMany()
                .HasForeignKey(p => p.IdPlanObraSocial);

            // Relación entre Pago y MetodoPago
            modelBuilder.Entity<Factura>()
                .HasOne(p => p.MetodoPago)
                .WithMany()
                .HasForeignKey(p => p.IdMetodoPago);
            // Relación entre PorcentajePagoMedico y Medico
            modelBuilder.Entity<PorcentajePagoMedico>()
                .HasOne(p => p.Medico)
                .WithMany(m => m.Porcentajes)
                .HasForeignKey(p => p.IdMedico);

            // Relación entre LiquidacionMedico y Medico
            modelBuilder.Entity<LiquidacionMedico>()
                .HasOne(l => l.Medico)
                .WithMany(m => m.Liquidaciones)
                .HasForeignKey(l => l.IdMedico);

            // Relación entre DetalleLiquidacionMedico y LiquidacionMedico
            modelBuilder.Entity<DetalleLiquidacionMedico>()
                .HasOne(d => d.LiquidacionMedico)
                .WithMany(l => l.Detalles)
                .HasForeignKey(d => d.IdLiquidacion);

            // Relación entre DetalleLiquidacionMedico y Turno
            modelBuilder.Entity<DetalleLiquidacionMedico>()
                .HasOne(d => d.Turno)
                .WithMany()
                .HasForeignKey(d => d.IdTurno);
        }
    }
}
