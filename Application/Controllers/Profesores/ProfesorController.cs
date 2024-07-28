using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTML_Componentes.Application.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly IProfesorRepository _profesorRepository;

        public ProfesorController(IProfesorRepository profesorRepository)
        {
            _profesorRepository = profesorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var profesores = await _profesorRepository.GetAllProfesoresAsync();
            return View(profesores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                await _profesorRepository.AddProfesorAsync(profesor);
                await _profesorRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var profesor = await _profesorRepository.GetProfesorByIdAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                await _profesorRepository.UpdateProfesorAsync(profesor);
                await _profesorRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await _profesorRepository.GetProfesorByIdAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _profesorRepository.DeleteProfesorAsync(id);
            await _profesorRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
