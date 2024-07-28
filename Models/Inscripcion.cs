using System;
using System.Collections.Generic;

namespace HTML_Componentes.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int Estudiante_Id { get; set; }
        public int Carrera_Id { get; set; }
        public int Profesor_Id { get; set; }
        public int Semestre_Id { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }
        public int Estado_Inscripcion_Id { get; set; }

        // Propiedades de navegación
        public Estudiante Estudiante { get; set; }
        public Carrera Carrera { get; set; }
        public Profesor Profesor { get; set; }
        public Semestre Semestre { get; set; }
        public Estado Estado { get; set; }
        
        // Propiedades adicionales
        public int Materia_Id { get; set; }
        public Materia Materia { get; set; }

        // Relación con Universidad a través de Inscripciones
        public ICollection<Universidad_Inscripcion> Universidades_Inscripciones { get; set; } = new List<Universidad_Inscripcion>();
    }
}
