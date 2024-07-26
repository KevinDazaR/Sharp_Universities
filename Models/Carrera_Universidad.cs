namespace HTML_Componentes.Models
{
    public class Carrera_Universidad
    {
        public int Carrera_Id { get; set; }
        public int Universidad_Id { get; set; }
        public Carrera ? Carrera { get; set; }
        public Universidad ? Universidad { get; set; }
    }
}