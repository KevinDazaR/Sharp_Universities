using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface IMateriaRepository
    {
        Task AddMateriaAsync(Materia materia);
        Task<Materia> GetMateriaByIdAsync(int id);
        Task<IEnumerable<Materia>> GetAllMateriasAsync();
        Task UpdateMateriaAsync(Materia materia);
        Task DeleteMateriaAsync(int id);
        Task SaveChangesAsync();
    }
}
