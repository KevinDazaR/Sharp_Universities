using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Interfaces
{
    public interface ICarreraRepository
    {
        Task AddCarreraAsync(Carrera carrera);
        Task<Carrera> GetCarreraByIdAsync(int id);
        Task<IEnumerable<Carrera>> GetAllCarrerasAsync();
        Task UpdateCarreraAsync(Carrera carrera);
        Task DeleteCarreraAsync(int id);
        Task SaveChangesAsync();
    }
}
