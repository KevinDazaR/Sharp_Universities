using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using HTML_Componentes.Models;


namespace HTML_Componentes.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Correo { get; set; }
        public string ? Telefono { get; set; } 
        public string ? Universidad_Id { get; set; }
        public string ? Estado_Id { get; set; }

          public Universidad ? Universidad { get; set; }
        public Estado ? Estado { get; set; }
        public ICollection<Estudiante_Materia> EstudiantesMaterias { get; set; } = new List<Estudiante_Materia>();

    }
}
