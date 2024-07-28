namespace HTML_Componentes.Models
{
   public class Materia
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public int ? Carrera_Id { get; set; }
        public Carrera?  Carrera { get; set; }
        public ICollection<Estudiante_Materia> Estudiantes_Materias { get; set; } = new List<Estudiante_Materia>();
        public ICollection<Profesor_Materia> Profesores_Materias { get; set; } = new List<Profesor_Materia>();
    }

}