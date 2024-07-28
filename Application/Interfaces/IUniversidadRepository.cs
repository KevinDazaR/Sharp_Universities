using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IUniversidadRepository
    {
        Task AddUniversidad(Universidad universidad);
        Task<Universidad> GetUniversidadById(int id);
        Task<IEnumerable<Universidad>> GetAllUniversidadesAsync();
        Task UpdateUniversidad(Universidad universidad);
        Task DeleteUniversidad(int id);
        Task SaveChangesAsync();
    }
}
