using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTML_Componentes.Application.Controllers
{
    public class MateriaController : Controller
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var materias = await _materiaRepository.GetAllMateriasAsync();
            return View(materias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Materia materia)
        {
            if (ModelState.IsValid)
            {
                await _materiaRepository.AddMateriaAsync(materia);
                await _materiaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var materia = await _materiaRepository.GetMateriaByIdAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            return View(materia);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Materia materia)
        {
            if (ModelState.IsValid)
            {
                await _materiaRepository.UpdateMateriaAsync(materia);
                await _materiaRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var materia = await _materiaRepository.GetMateriaByIdAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            return View(materia);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _materiaRepository.DeleteMateriaAsync(id);
            await _materiaRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
