using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Services
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly BaseContext _context;

        public MateriaRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddMateriaAsync(Materia materia)
        {
            await _context.Materias.AddAsync(materia);
        }

        public async Task<Materia> GetMateriaByIdAsync(int id)
        {
            return await _context.Materias.FindAsync(id);
        }

        public async Task<IEnumerable<Materia>> GetAllMateriasAsync()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task UpdateMateriaAsync(Materia materia)
        {
            _context.Materias.Update(materia);
        }

        public async Task DeleteMateriaAsync(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
