using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Services
{
    public class InscripcionRepository : IInscripcionRepository
    {
        private readonly BaseContext _context;

        public InscripcionRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inscripcion>> GetAllInscripcionesAsync()
        {
            return await _context.Inscripciones.ToListAsync();
        }

        public async Task<Inscripcion> GetInscripcionByIdAsync(int id)
        {
            return await _context.Inscripciones.FindAsync(id);
        }

        public async Task AddInscripcionAsync(Inscripcion inscripcion)
        {
            await _context.Inscripciones.AddAsync(inscripcion);
        }

        public async Task UpdateInscripcionAsync(Inscripcion inscripcion)
        {
            _context.Inscripciones.Update(inscripcion);
        }

        public async Task DeleteInscripcionAsync(int id)
        {
            var inscripcion = await _context.Inscripciones.FindAsync(id);
            if (inscripcion != null)
            {
                _context.Inscripciones.Remove(inscripcion);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
