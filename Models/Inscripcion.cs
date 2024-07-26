namespace HTML_Componentes.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int CarreraId { get; set; }
        public int ProfesorId { get; set; }
        public int SemestreId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int EstadoInscripcionId { get; set; }
        public Estudiante ? Estudiante { get; set; }
        public Carrera ? Carrera { get; set; }
        public Profesor ? Profesor { get; set; }
        public Semestre ? Semestre { get; set; }
        public Estado ? Estado { get; set; }
        public ICollection<Universidad_Inscripcion> UniversidadesInscripciones { get; set; } = new List<Universidad_Inscripcion>();
    }

}