using Microsoft.EntityFrameworkCore;
using HTML_Componentes.Models;

namespace HTML_Componentes.Infrastructure.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }
        
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Universidad> Universidades { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Estudiante_Materia> Estudiantes_Materias { get; set; }
        public DbSet<Profesor_Materia> Profesores_Materias { get; set; }
        public DbSet<Carrera_Materia> Carreras_Materias { get; set; }
        public DbSet<Profesor_Universidad> Profesores_Universidades { get; set; }
        public DbSet<Carrera_Universidad> Carreras_Universidades { get; set; }
        public DbSet<Universidad_Inscripcion> Universidades_Inscripciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de las claves compuestas para las tablas intermedias
            modelBuilder.Entity<Estudiante_Materia>()
                .HasKey(em => new { em.Estudiante_Id, em.Materia_Id });

            modelBuilder.Entity<Profesor_Materia>()
                .HasKey(pm => new { pm.Profesor_Id, pm.Materia_Id });

            modelBuilder.Entity<Carrera_Materia>()
                .HasKey(cm => new { cm.Carrera_Id, cm.Materia_Id });

            modelBuilder.Entity<Profesor_Universidad>()
                .HasKey(pu => new { pu.Profesor_Id, pu.Universidad_Id });

            modelBuilder.Entity<Carrera_Universidad>()
                .HasKey(cu => new { cu.Carrera_Id, cu.Universidad_Id });

            modelBuilder.Entity<Universidad_Inscripcion>()
                .HasKey(ui => new { ui.Universidad_Id, ui.Inscripcion_Id });
        }
    }
}
