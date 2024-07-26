namespace HTML_Componentes.Models
{
    public class Carrera
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public ICollection<Carrera_Materia> CarrerasMaterias { get; set; } = new List<Carrera_Materia>();
        public ICollection<Carrera_Universidad> CarrerasUniversidades { get; set; } = new List<Carrera_Universidad>();
    }

}