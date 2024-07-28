using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly BaseContext _context;

        public EstudianteRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddEstudiante(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
        }

        public async Task<Estudiante> GetEstudianteById(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudiantesAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task UpdateEstudiante(Estudiante estudiante)
        {
            _context.Estudiantes.Update(estudiante);
            await Task.CompletedTask;
        }

        public async Task DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
