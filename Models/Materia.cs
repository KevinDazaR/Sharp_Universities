namespace HTML_Componentes.Models
{
   public class Materia
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public int ? CarreraId { get; set; }
        public Carrera?  Carrera { get; set; }
        public ICollection<Estudiante_Materia> EstudiantesMaterias { get; set; } = new List<Estudiante_Materia>();
        public ICollection<Profesor_Materia> ProfesoresMaterias { get; set; } = new List<Profesor_Materia>();
    }

}