using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IInscripcionRepository
    {
        Task<IEnumerable<Inscripcion>> GetAllInscripcionesAsync();
        Task<Inscripcion> GetInscripcionByIdAsync(int id);
        Task AddInscripcionAsync(Inscripcion inscripcion);
        Task UpdateInscripcionAsync(Inscripcion inscripcion);
        Task DeleteInscripcionAsync(int id);
        Task SaveChangesAsync();
    }
}
