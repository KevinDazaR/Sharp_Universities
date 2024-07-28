// SemestreRepository.cs
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class SemestreRepository : ISemestreRepository
    {
        private readonly BaseContext _context;

        public SemestreRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddSemestreAsync(Semestre semestre)
        {
            await _context.Semestres.AddAsync(semestre);
        }

        public async Task<Semestre> GetSemestreByIdAsync(int id)
        {
            return await _context.Semestres.FindAsync(id);
        }

        public async Task<IEnumerable<Semestre>> GetAllSemestresAsync()
        {
            return await _context.Semestres.ToListAsync();
        }

        public async Task UpdateSemestreAsync(Semestre semestre)
        {
            _context.Semestres.Update(semestre);
        }

        public async Task DeleteSemestreAsync(int id)
        {
            var semestre = await _context.Semestres.FindAsync(id);
            if (semestre != null)
            {
                _context.Semestres.Remove(semestre);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}