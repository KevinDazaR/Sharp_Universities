using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface ISemestreRepository
    {
        Task AddSemestreAsync(Semestre semestre);
        Task<Semestre> GetSemestreByIdAsync(int id);
        Task<IEnumerable<Semestre>> GetAllSemestresAsync();
        Task UpdateSemestreAsync(Semestre semestre);
        Task DeleteSemestreAsync(int id);
        Task SaveChangesAsync();
    }
}
