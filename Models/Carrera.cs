namespace HTML_Componentes.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public ICollection<Carrera_Materia> Carreras_Materias { get; set; } = new List<Carrera_Materia>();
        public ICollection<Carrera_Universidad> Carreras_Universidades { get; set; } = new List<Carrera_Universidad>();
    }

}