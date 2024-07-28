// CarreraRepository.cs
using HTML_Componentes.Infrastructure.Data;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HTML_Componentes.Application.Services
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly BaseContext _context;

        public CarreraRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task AddCarreraAsync(Carrera carrera)
        {
            await _context.Carreras.AddAsync(carrera);
        }

        public async Task<Carrera> GetCarreraByIdAsync(int id)
        {
            return await _context.Carreras.FindAsync(id);
        }

        public async Task<IEnumerable<Carrera>> GetAllCarrerasAsync()
        {
            return await _context.Carreras.ToListAsync();
        }

        public async Task UpdateCarreraAsync(Carrera carrera)
        {
            _context.Carreras.Update(carrera);
        }

        public async Task DeleteCarreraAsync(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
