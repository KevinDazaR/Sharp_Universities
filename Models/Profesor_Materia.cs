namespace HTML_Componentes.Models
{
   public class Profesor_Materia
    {
        public int Profesor_Id { get; set; }
        public int Materia_Id { get; set; }
        public Profesor ? Profesor { get; set; }
        public Materia ? Materia { get; set; }
    }

}