namespace HTML_Componentes.Models
{
    public class Profesor_Universidad
    {
        public int Profesor_Id { get; set; }
        public int Universidad_Id { get; set; }
         public Profesor ? Profesor { get; set; }
        public Universidad ? Universidad { get; set; }
    }
}