using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTML_Componentes.Application.Controllers
{
    public class CarreraController : Controller
    {
        private readonly ICarreraRepository _carreraRepository;

        public CarreraController(ICarreraRepository carreraRepository)
        {
            _carreraRepository = carreraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carreras = await _carreraRepository.GetAllCarrerasAsync();
            return View(carreras);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                await _carreraRepository.AddCarreraAsync(carrera);
                await _carreraRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var carrera = await _carreraRepository.GetCarreraByIdAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                await _carreraRepository.UpdateCarreraAsync(carrera);
                await _carreraRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var carrera = await _carreraRepository.GetCarreraByIdAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            return View(carrera);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carreraRepository.DeleteCarreraAsync(id);
            await _carreraRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
