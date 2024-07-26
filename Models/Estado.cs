namespace HTML_Componentes.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string? Nombre_Estado { get; set; }
        public string? Tipo_Estado { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }

}