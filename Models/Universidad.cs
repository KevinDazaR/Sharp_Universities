namespace HTML_Componentes.Models
{
    public class Universidad
    {
        public int ? Id { get; set; }
        public string ? Nombre { get; set; }
        public string ? Decano { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
        public ICollection<Carrera_Universidad> Carreras_Universidades { get; set; } = new List<Carrera_Universidad>();
        public ICollection<Profesor_Universidad> Profesores_Universidades { get; set; } = new List<Profesor_Universidad>();
        }
}