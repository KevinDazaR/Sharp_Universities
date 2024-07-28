using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IProfesorRepository
    {
        Task AddProfesorAsync(Profesor profesor);
        Task<Profesor> GetProfesorByIdAsync(int id);
        Task<IEnumerable<Profesor>> GetAllProfesoresAsync();
        Task UpdateProfesorAsync(Profesor profesor);
        Task DeleteProfesorAsync(int id);
        Task SaveChangesAsync();
    }
}
