using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class UniversidadRepository : IUniversidadRepository
    {
        private readonly BaseContext _context;

        public UniversidadRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddUniversidad(Universidad universidad)
        {
            await _context.Universidades.AddAsync(universidad);
        }

        public async Task<Universidad> GetUniversidadById(int id)
        {
            return await _context.Universidades.FindAsync(id);
        }

        public async Task<IEnumerable<Universidad>> GetAllUniversidadesAsync()
        {
            return await _context.Universidades.ToListAsync();
        }

        public async Task UpdateUniversidad(Universidad universidad)
        {
            _context.Universidades.Update(universidad);
            await Task.CompletedTask;
        }

        public async Task DeleteUniversidad(int id)
        {
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad != null)
            {
                _context.Universidades.Remove(universidad);
            }
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
