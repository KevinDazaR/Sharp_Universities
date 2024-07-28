using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IEstudianteRepository
    {
        Task AddEstudiante(Estudiante estudiante);
        Task<Estudiante> GetEstudianteById(int id);
        Task<IEnumerable<Estudiante>> GetAllEstudiantesAsync();
        Task UpdateEstudiante(Estudiante estudiante);
        Task DeleteEstudiante(int id);
        Task SaveChangesAsync();
    }
}
