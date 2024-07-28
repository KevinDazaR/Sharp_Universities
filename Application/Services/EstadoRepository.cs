using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly BaseContext _context;

        public EstadoRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddEstadoAsync(Estado estado)
        {
            await _context.Estados.AddAsync(estado);
        }

        public async Task<Estado> GetEstadoByIdAsync(int id)
        {
            return await _context.Estados.FindAsync(id);
        }

        public async Task<IEnumerable<Estado>> GetAllEstadosAsync()
        {
            return await _context.Estados.ToListAsync();
        }

        public async Task UpdateEstadoAsync(Estado estado)
        {
            _context.Estados.Update(estado);
        }

        public async Task DeleteEstadoAsync(int id)
        {
            var estado = await _context.Estados.FindAsync(id);
            if (estado != null)
            {
                _context.Estados.Remove(estado);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
