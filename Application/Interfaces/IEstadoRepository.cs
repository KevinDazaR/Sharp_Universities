using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IEstadoRepository
    {
        Task AddEstadoAsync(Estado estado);
        Task<Estado> GetEstadoByIdAsync(int id);
        Task<IEnumerable<Estado>> GetAllEstadosAsync();
        Task UpdateEstadoAsync(Estado estado);
        Task DeleteEstadoAsync(int id);
        Task SaveChangesAsync();
    }
}
