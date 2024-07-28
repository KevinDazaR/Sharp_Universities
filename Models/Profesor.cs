namespace HTML_Componentes.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Correo { get; set; }
        public string ? Telefono { get; set; }
        public int Universidad_Id { get; set; }
        public Universidad Universidad { get; set; }
        public ICollection<Profesor_Materia> Profesores_Materias { get; set; } = new List<Profesor_Materia>();
        public ICollection<Profesor_Universidad> Profesores_Universidades { get; set; } = new List<Profesor_Universidad>();
    }

}