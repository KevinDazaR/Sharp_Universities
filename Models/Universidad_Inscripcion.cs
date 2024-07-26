namespace HTML_Componentes.Models
{
    public class Universidad_Inscripcion
    {
        public int Universidad_Id { get; set;}
        public int Inscripcion_Id { get; set;}
        public Universidad ? Universidad { get; set; }
        public Inscripcion ? Inscripcion { get; set; }
    }
}