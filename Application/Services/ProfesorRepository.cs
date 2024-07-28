// ProfesorRepository.cs
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly BaseContext _context;

        public ProfesorRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddProfesorAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
        }

        public async Task<Profesor> GetProfesorByIdAsync(int id)
        {
            return await _context.Profesores.FindAsync(id);
        }

        public async Task<IEnumerable<Profesor>> GetAllProfesoresAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task UpdateProfesorAsync(Profesor profesor)
        {
            _context.Profesores.Update(profesor);
        }

        public async Task DeleteProfesorAsync(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}